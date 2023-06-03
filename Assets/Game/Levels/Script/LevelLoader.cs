using System;
using UnityEngine.SceneManagement;
[Serializable]
public class LevelLoader 
{
    public int SceneCount => SceneManager.sceneCount;

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

}
