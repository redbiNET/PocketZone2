
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManeger", menuName = "Levels")]
public class LevelManeger : ScriptableObject
{
    [SerializeField] private LevelLoader _loader;
    [SerializeField] private LevelSaver _saver;
    public void Quit()
    {
        Application.Quit();
    }
    public void ReloadLevel()
    {
         _loader.LoadLevel(_saver.GetLastLevel());
    }
    public void ResetSaves()
    {
        _saver.SaveLastLevel(1);
    }
}
