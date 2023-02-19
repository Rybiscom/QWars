using System.Collections.Generic;
using UnityEngine;

public sealed class GameMap : MonoBehaviour, IActivable
{
    [SerializeField] private Maps.Names _mapName;

    private const string SPAWN_FIELDS_PATCH_NAME = "SpawnFields";
    private const string SPAWN_NAME = "Spawn";

    private const float LOCAL_SCALE_FACTOR = 2f;

    private Transform _spawnFieldsPatch;
    private List<Transform> _spawnFields = new List<Transform>();

    private void Start()
    {
        _spawnFieldsPatch = gameObject.transform.Find(SPAWN_FIELDS_PATCH_NAME);

        UpdateAllSpawnFields(_spawnFields);
    }

    public Maps.Names GetMapName() => _mapName;

    public void Activate() 
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public Vector3 GetRandomPoint()
    {
        Transform randomField = _spawnFields[Random.Range(0, _spawnFields.Count)];

        float offsetPointX = randomField.position.x - randomField.localScale.x / LOCAL_SCALE_FACTOR;
        float offsetPointY = randomField.position.y + randomField.localScale.y / LOCAL_SCALE_FACTOR;

        float randomPointX = Random.Range(offsetPointX, offsetPointX + randomField.localScale.x);
        float randomPointY = Random.Range(offsetPointY, offsetPointY - randomField.localScale.y);

        return new Vector3(randomPointX, randomPointY, randomField.position.z);
    }

    private void UpdateAllSpawnFields(List<Transform> spawnFields)
    {
        foreach (Transform child in _spawnFieldsPatch)
        {
            if (child.name.Equals(SPAWN_NAME))
                spawnFields.Add(child);
        }
    }
}
