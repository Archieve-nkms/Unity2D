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
        _currenthp = _enemyInfo.HP;
        _faction = Faction.Enemy;
    }

    private void Update()
    {
        if (CanFire)
        {
            Vector3 dir = (Managers.Game.Player.transform.position - transform.position).normalized;
            _enemyInfo.Weapon.Fire(this, dir, out _nextFireTick);
        }
    }


    protected override void OnDead()
    {
        Destroy(this.gameObject);
    }
}