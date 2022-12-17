using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : BaseUnit
{
    [SerializeField]
    EnemyInfo _enemyInfo;
    [SerializeField]
    BaseMovement _movement;

    public string CodeName => _enemyInfo.CodeName;
    public string DisplayName => _enemyInfo.DisplayName;

    float _setupTime = 1f;
    bool _canMove = false;
    bool _canFire = false;

    private void OnEnable()
    {
        _currenthp = _enemyInfo.HP;
        _canMove = false;
        _canFire = false;

        Vector3 targetPos = Random.Range(0, 2) == 0 ? Managers.Game.Player.transform.position : transform.position;
        List<BaseMovement> movements = GetComponents<BaseMovement>().ToList();
        int randomValue = Random.Range(1, 7);

        _movement = movements[Random.Range(0, movements.Count)];
        _movement.SetUp(transform, targetPos, _enemyInfo.Speed, randomValue);

        StartCoroutine(SleepForSeconds(_setupTime));
    }

    private void Awake()
    {
        _currenthp = _enemyInfo.HP;
        _faction = Faction.Enemy;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (_canFire && WeaponReadyToFire)
        {
            Vector3 dir = (Managers.Game.Player.transform.position - transform.position).normalized;
            _enemyInfo.Weapon.Fire(this, dir, out _nextFireTick);
        }

        if (_canMove)
        {
            _movement.SetDestination(Managers.Game.Player.transform.position);
            _movement.Move();
        }
    }

    protected override void OnDead()
    {
        Managers.Game.KillCount++;
        gameObject.SetActive(false);
    }

    IEnumerator SleepForSeconds(float seconds)
    {
        _canMove = false;
        _canFire = false;   
        yield return new WaitForSeconds(seconds);
        _canMove = true;
        _canFire = true;
    }
}