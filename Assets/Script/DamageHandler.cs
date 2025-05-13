using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private Weapon _weapon;

    private void Awake()
    {
        _weapon = GetComponentInParent<Weapon>();
    }

    public void Fire()
    {
        _weapon.Damage();
    }
}
