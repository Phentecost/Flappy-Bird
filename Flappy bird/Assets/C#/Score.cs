using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static Score Instance { get; private set; } = null;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if(Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        _currentScoreText.text = _score.ToString();

        _highScoreText.text = Game_Data._bestScore.ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore() 
    {
        if(_score > Game_Data._bestScore) 
        {
            Game_Data.Update_Score();
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore() 
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();  
    }
}
