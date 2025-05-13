using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float spawnTime;
    

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            spawnTime = 4;
        }
    }
}
