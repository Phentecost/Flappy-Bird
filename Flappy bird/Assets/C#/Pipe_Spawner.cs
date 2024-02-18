using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pipe_Spawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject [] _pipes;

    private GameObject _pipe;
    private ObjectPool<GameObject> _pipePool;
    private float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _pipe = _pipes[Game_Data._backGround];

        _pipePool = new ObjectPool<GameObject>(() => 
        {
            return Instantiate(_pipe);
        }, pipe => 
        {
            pipe.SetActive(true);
        }, pipe => 
        {
            pipe.SetActive(false);
        }, pipe => 
        {
            Destroy(pipe.gameObject);
        },false,10,15);

        SpawnPipe();
    }

    private void SpawnPipe() 
    {
        Vector3 spawnPos = transform.position + new Vector3(0,Random.Range(-_heightRange,_heightRange));
        GameObject pipe = _pipePool.Get();
        pipe.transform.position = spawnPos;
        pipe.GetComponent<Pipes_Movements>().Init(Reset_Pipe);
    }

    private void Reset_Pipe(GameObject pipe) 
    {
        _pipePool.Release(pipe);
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer > _maxTime) 
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}
