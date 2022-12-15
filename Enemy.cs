using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{
    [SerializeField]
    EnemyInfo _enemyInfo;

    public string CodeName => _enemyInfo.CodeName;
    public string DisplayName => _enemyInfo.DisplayName;


    private void Awake()
    {
        _enemyInfo.Weapon.SetOwner(this.gameObject);
    }

    private override void OnDead()
    {
        Destroy(this.gameObject);
    }
}