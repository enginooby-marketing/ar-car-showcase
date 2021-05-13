using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    public int currentCarId;

    private static AppController _instance;

    public static AppController Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
