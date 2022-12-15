using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit
{
    [SerializeField]
    int _maxHp;
    [SerializeField]
    BaseWeapon _weapon;

    private void Awake()
    {
        _faction = Faction.Ally;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(CanFire)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 dir = (mousePosition - this.transform.position).normalized;
                _weapon.Fire(this, dir, out _nextFireTick);
            }
        }
    }

    protected override void OnDead()
    {
        //TODO
    }
}