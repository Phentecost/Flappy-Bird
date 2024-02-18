using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes_Movements : MonoBehaviour
{

    [SerializeField] private float _speed = 0.65f;

    private float _timer = 10;
    private Action<GameObject> _kill;

    
    public void Init(Action<GameObject> kill) 
    {
        _kill = kill;
        _timer = 10;
    }

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (_timer < 0 ) 
        {
            _kill(this.gameObject);
        }

        _timer -= Time.deltaTime;
    }
}
