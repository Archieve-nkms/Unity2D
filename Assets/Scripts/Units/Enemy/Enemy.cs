using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{
    [SerializeField]
    EnemyInfo _enemyInfo;
    [SerializeField]
    BaseMovement _movement;

    public string CodeName => _enemyInfo.CodeName;
    public string DisplayName => _enemyInfo.DisplayName;

    Vector3 dir; 

    private void Awake()
    {
        _currenthp = _enemyInfo.HP;
        _faction = Faction.Enemy;
    }

    private void Start()
    {
        _movement.SetUp(transform, Managers.Game.Player.transform.position, _enemyInfo.Speed);
    }

    private void Update()
    {
        dir = (Managers.Game.Player.transform.position - transform.position).normalized;

        if (CanFire)
        {
            Vector3 dir = (Managers.Game.Player.transform.position - transform.position).normalized;
            _enemyInfo.Weapon.Fire(this, dir, out _nextFireTick);
        }
    }

    private void FixedUpdate()
    {
        _movement.SetDestination(Managers.Game.Player.transform.position);
        _movement.Move();
    }

    protected override void OnDead()
    {
        gameObject.SetActive(false);
    }
}