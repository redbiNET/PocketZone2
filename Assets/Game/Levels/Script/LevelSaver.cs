
using System;
using UnityEngine;

[Serializable]
public class LevelSaver
{
    [SerializeField] private int _level = 1;
    public void SaveLastLevel(int lvl)
    {
        _level = lvl;
    }
    
    public int GetLastLevel()
    {
        return _level;
    }
}
