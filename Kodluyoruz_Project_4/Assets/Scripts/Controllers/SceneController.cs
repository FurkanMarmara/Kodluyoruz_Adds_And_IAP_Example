using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public static SceneController instance;

    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

        }
        else
        {
            instance = this;
        }
        #endregion
    }


    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }


}

public enum Scenes
{
    PreGameScene,
    PlayGameScene,
    EndGameScene
}