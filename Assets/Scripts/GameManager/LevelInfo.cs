public sealed class LevelInfo
{
    public LevelInfo(int level)
    {
        if (CheckLevel(level))
            Current = level;
        else
            Current = 0;

        Level = Config.LevelsInfo.Levels[Current];

        WaveIteration = 0;
    }

    public readonly int Current;
    public readonly ConfigLevels.Level Level;

    public int WaveIteration { get; private set; }

    public int GetCoins() => Level.Coins;

    public int GetRubins() => Level.Rubins;

    public bool TryGoToNextWave(out int newWaveIteration)
    {
        newWaveIteration = WaveIteration + 1;

        if (Level.LevelWaves.Length > newWaveIteration)
        {
            WaveIteration = newWaveIteration;

            return true;
        }
        else
        {
            newWaveIteration = 0;

            return false;
        }
    }

    public bool CheckLevel(int level)
    {
        return Config.LevelsInfo.Levels.ContainsKey(level);
    }

    public int GetLevelsCount()
    {
        return Config.LevelsInfo.Levels.Count;
    }

    public ConfigLevels.OneCopter[] GetCopters(int waveIteration)
    {
        return Level.LevelWaves[waveIteration].Copters;
    }

    public string GetWaveName(int waveIteration)
    {
        return Level.LevelWaves[waveIteration].Name;
    }

}
