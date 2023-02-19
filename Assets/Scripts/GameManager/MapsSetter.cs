using UnityEngine;

public sealed class MapsSetter : MonoBehaviour
{
    [SerializeField] private GameMap[] _maps;

    private GameMap _currentMap;

    public void Set(Maps.Names name)
    {
        for (int i = 0; i < _maps.Length; i++)
        {
            if (_maps[i].GetMapName() == name)
            {
                _maps[i].Activate();
                _currentMap = _maps[i];
            }
            else
            {
                _maps[i].Deactivate();
            }
        }
    }

    public Vector3 GetRandomPoint()
    {
        if (_currentMap != null)
            return _currentMap.GetRandomPoint();
        else
            return new Vector3(0, 0, 1);
    }
}
