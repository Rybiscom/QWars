using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CopterSpawn))]
[RequireComponent(typeof(CopterBubbles))]

public sealed class GameManager : MonoBehaviour
{
    private const float TIME_LOOP = 0.5f;

    private bool _playerDeathCheker = false;
    private bool _playerWin = false;
    private bool _active = true;

    private CopterSpawn _copterSpawn;
    private MapsSetter _mapsSetter;
    private GameInterface _gameInterface;
    private CameraController _cameraController;
    private CopterBubbles _copterBubbles;

    private SlowMotion _slowMotion;
    private LevelInfo _levelInfo;

    private IOpenCopter _player;

    private void Start()
    {
        _copterSpawn = GetComponent<CopterSpawn>();
        _mapsSetter = GameObject.FindWithTag(Tags.Maps).GetComponent<MapsSetter>();
        _gameInterface = GameObject.FindWithTag(Tags.Interface).GetComponent<GameInterface>();
        _cameraController = Camera.main.gameObject.GetComponent<CameraController>();
        _copterBubbles = GetComponent<CopterBubbles>();

        _slowMotion = new SlowMotion();
        _levelInfo = InitLevel();

        StartGame();
    }

    private void FixedUpdate()
    {
        if (!_active)
            return;

        SlowMotionControl();
        BubblesControl();
        CameraControl();
    }

    private void OnDestroy()
    {
        Deactivate();
    }

    private void StartGame()
    {
        SetMap();

        InitInterface();

        UpdateInterfaceBubbles();

        Config.CoptersInfo.Names playerCopterName = Config.CoptersInfo.GetEnumName(GameStorage.PlayerCopter.GetCurrentPlayerCopter());
        StartCoroutine(SpawnPlayer(playerCopterName));

        StartCoroutine(MainLoop());

        StartCoroutine(RunWave());
    }

    private IEnumerator MainLoop()
    {
        while (_active)
        {
            UpdatePlayerDead();

            yield return new WaitForSeconds(TIME_LOOP);
        }
    }

    private IEnumerator RunWave()
    {
        int waveIteration = _levelInfo.WaveIteration;

        // Приветствие
        yield return new WaitForSeconds(2f);
        _gameInterface.SpawnText(_levelInfo.GetWaveName(waveIteration));
        yield return new WaitForSeconds(2f);

        // Обратный отсчет
        _gameInterface.SpawnText("3");
        yield return new WaitForSeconds(1f);
        _gameInterface.SpawnText("2");
        yield return new WaitForSeconds(1f);
        _gameInterface.SpawnText("1");
        yield return new WaitForSeconds(1f);

        // Спавним ботов
        List<IOpenCopter> bots = new List<IOpenCopter>();
        SpawnAllBotsForWave(waveIteration, bots);

        if (bots.Count > 1)
            _gameInterface.SpawnText($"{bots.Count} bots spawned");
        else
            _gameInterface.SpawnText($"One bot spawned");

        while (true)
        {
            yield return new WaitForSeconds(TIME_LOOP);

            bool atLeastOneBotIsAlive = false;

            for (int i = 0; i < bots.Count; i++)
            {
                if (!bots[i].GetDeath())
                    atLeastOneBotIsAlive = true;
            }

            if (!atLeastOneBotIsAlive)
                break;
        }

        if (_player.GetDeath())
            yield break;

        if (_levelInfo.TryGoToNextWave(out int newWaveIteration))
        {
            StartCoroutine(RunWave());

            yield break;
        }

        // Обратный отсчет до победы
        _gameInterface.SpawnText($"Good job!");
        yield return new WaitForSeconds(1f);
        _gameInterface.SpawnText("3");
        yield return new WaitForSeconds(1f);
        _gameInterface.SpawnText("2");
        yield return new WaitForSeconds(1f);
        _gameInterface.SpawnText("1");
        yield return new WaitForSeconds(1f);

        if (_player.GetDeath())
            yield break;

        StartCoroutine(PlayerWin());
    }

    private IEnumerator PlayerWin()
    {
        if (_player.GetDeath())
            yield break;

        _playerWin = true;

        PlayerLevelUp();

        _gameInterface.ShowOne(_gameInterface.CanvasWin);

        yield return null;

        AddWinMoney();
    }

    private void PlayerLevelUp()
    {
        GameStorage.Level.LevelUp();
    }

    private void AddWinMoney()
    {
        int coins = _levelInfo.GetCoins();
        int rubins = _levelInfo.GetRubins();

        _gameInterface.CoinsWin.StartSmoothCount(0, coins);
        _gameInterface.RubinsWin.StartSmoothCount(0, rubins);

        GameStorage.Money.AddCoins(coins);
        GameStorage.Money.AddRubins(rubins);
    }

    private void GoToMenu()
    {
        _gameInterface.GoToMenu();
    }

    private LevelInfo InitLevel()
    {
        return new LevelInfo(GameStorage.Level.GetLevel());
    }

    private void SlowMotionControl()
    {
        if (_player == null)
            return;

        bool slowMotionKey = _player.GetInputHandler()?.GetState(IInputHandler.Action.SlowMotionKey) ?? false;

        _slowMotion.Iteration(slowMotionKey);
        _cameraController.SlowMotion(slowMotionKey, _slowMotion.GetInvertTimeScale());
    }

    private void BubblesControl()
    {
        if (_player == null)
            return;

        BubblesStates bubblesStates = new BubblesStates
        {
            God = _player.GetInputHandler()?.GetState(IInputHandler.Action.BubbleGodKey) ?? false,
            Damage = _player.GetInputHandler()?.GetState(IInputHandler.Action.BubbleDamageKey) ?? false
        };

        if (!bubblesStates.IsOneActive())
            return;

        _copterBubbles.UpdateStates(bubblesStates);
        _copterBubbles.CreateBubble(_player.GetHeadRgidBody(), _player);

        UpdateInterfaceBubbles();
    }

    private void CameraControl()
    {
        if (_player == null)
            return;

        _cameraController.UpdateOrthographicSizeByTargetSpeed();
    }

    private void Deactivate()
    {
        _active = false;
    }

    private void SetMap()
    {
        _mapsSetter.Set(Maps.Names.Map1);
    }

    private void InitInterface()
    {
        _gameInterface.ShowOne(_gameInterface.CanvasInput);
    }

    private void UpdateInterfaceBubbles()
    {
        Bubbles.Names BubbleGod = Bubbles.Names.BubbleGod;
        Bubbles.Names BubbleDamage = Bubbles.Names.BubbleDamage;

        int bubbleGodCounts = GameStorage.Bubbles.GetCounts(BubbleGod);
        int bubbleDamageCounts = GameStorage.Bubbles.GetCounts(BubbleDamage);

        bool showBubbleGod = bubbleGodCounts > 0;
        bool showBubbleDamage = bubbleDamageCounts > 0;

        _gameInterface.BubbleElements.ShowBubble(BubbleGod, showBubbleGod);
        _gameInterface.BubbleElements.ShowBubble(BubbleDamage, showBubbleDamage);
    }

    private IEnumerator SpawnPlayer(Config.CoptersInfo.Names name)
    {
        Vector3 randomPoint = _mapsSetter.GetRandomPoint();

        _player = _copterSpawn.Spawn(name, true, randomPoint).GetComponent<Player>();

        yield return null;

        InitCamera(_player);
    }

    private void SpawnBots(Config.CoptersInfo.Names name, List<IOpenCopter> bots)
    {
        Vector3 randomPoint = _mapsSetter.GetRandomPoint();

        IOpenCopter bot = _copterSpawn.Spawn(name, false, randomPoint).GetComponent<Bot>();

        bots.Add(bot);

        StartCoroutine(SpawnAttentionPointer(_cameraController.gameObject.transform, bot));
    }

    private void InitCamera(IOpenCopter player)
    {
        _cameraController.InitCopterInfo(player.GetCurrentCopterInfo());

        _cameraController.SetTarget(player.GetHeadGameObject());
    }

    private IEnumerator SpawnAttentionPointer(Transform targetFrom, IOpenCopter bot)
    {
        yield return null;

        _gameInterface.SpawnAttentionPointer(targetFrom, bot.GetHeadGameObject().transform);
    }

    private void SpawnAllBotsForWave(int waveIteration, List<IOpenCopter> bots)
    {
        ConfigLevels.OneCopter[] copters = _levelInfo.GetCopters(waveIteration);

        for (int i = 0; i < copters.Length; i++)
            SpawnBots(copters[i].Name, bots);
    }
    
    private void UpdatePlayerDead()
    {
        if (_playerWin)
            return;

        if (_player.GetDeath())
            StartCoroutine(PlayerDead());
    }

    private IEnumerator PlayerDead()
    {
        if (_playerDeathCheker || _playerWin)
            yield break;
        _playerDeathCheker = true;

        yield return new WaitForSeconds(2f);

        _gameInterface.ShowOne(_gameInterface.CanvasDeath);
    }
}
