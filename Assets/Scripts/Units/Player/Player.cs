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
        _currenthp = _maxHp;
    }

    private void OnEnable()
    {
        _currenthp = _maxHp;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(WeaponReadyToFire)
            {
                Fire();
            }
        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        FindObjectOfType<TextRemainingHP>().UpdateText();
    }

    protected override void OnDead()
    {
        gameObject.SetActive(false);
        Managers.Game.EndGame();
    }

    public override void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir3D = (mousePosition - this.transform.position);
        Vector2 direction = new Vector2(dir3D.x, dir3D.y).normalized;
        _weapon.Fire(this, direction, out _nextFireTick);
    }
}