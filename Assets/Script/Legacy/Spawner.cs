using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obj;
    [SerializeField] private float spawnTime;
    private float _spawnTime;

    private void Start()
    {
        _spawnTime = Random.Range(1, spawnTime);
    }

    void Update()
    {
        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0)
        {
            Instantiate(obj[Random.Range(0,obj.Count)], transform.position, Quaternion.identity);
            _spawnTime = Random.Range(1, spawnTime);
        }
    }
}
