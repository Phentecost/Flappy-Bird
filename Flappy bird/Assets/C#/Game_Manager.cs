using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{

    public static Game_Manager instance { get; private set; } = null;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _birdOBJ;
    [SerializeField] private GameObject _backGroundOBJ;

    public int _birdColor;
    public int _backGround;

    private void Awake()
    {
        if(instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        Game_Data.Randomize_Scene();

        _birdColor = Game_Data._birdColor;

        _backGround = Game_Data._backGround;

        _birdOBJ.transform.GetChild(_birdColor).gameObject.SetActive(true);

        _backGroundOBJ.transform.GetChild(_backGround).gameObject.SetActive(true);



        Time.timeScale = 1.0f;
    }

    public void GameOver() 
    {
        _gameOverCanvas.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
