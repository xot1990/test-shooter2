using System;
using System.Collections;
using System.Collections.Generic;
using DiabolicalGames;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    [SerializeField] private int _hp;
    private DestructibleObject obj;
    private Vector3 dir;
    private void Awake()
    {
        obj = GetComponent<DestructibleObject>();
        dir = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2)).normalized;
    }

    private void Update()
    {
        transform.Translate(dir * 3 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        dir = new Vector3(Random.Range(-2, 2f), 0, Random.Range(-2, 2f)).normalized * -1;
    }

    public void Hit(Vector3 pos)
    {
        _hp -= 1;
        Instantiate(effect, pos, Quaternion.identity);
        
        if(_hp <= 0)
        {
            obj.Break();
            QuestEventBus.GetEnemyDie(this);
        }
    }
}
