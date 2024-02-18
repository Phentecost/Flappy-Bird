using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager instance { get; private set; } = null;

    private void Awake()
    {
        if(instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Go_to_Game() 
    {
        SceneManager.LoadScene(1);
    }

    public void Go_to_Main () 
    {
        SceneManager.LoadScene(0);
    }
}
