using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Score : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player_Controller p = collision.GetComponent<Player_Controller>();
        if(p != null) 
        {
            Score.Instance.UpdateScore();
        }
    }
}
