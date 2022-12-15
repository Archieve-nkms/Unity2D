using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Gun", fileName = "Gun_")]
public class Gun : BaseWeapon
{
    [Header("Projectile")]
    [SerializeField]
    GameObject _projectile;
    [SerializeField]
    int _projectileAmount;
    [SerializeField]
    [Range(50, 200)]
    float _projectileSpeed;

    public int ProjectileAmount => _projectileAmount;
    public float ProjectileSpeed => _projectileSpeed;

    public override void Fire(BaseUnit owner, Vector3 direction, out float nextFireTick)
    {
        nextFireTick = Time.time + _firerate;

        GameObject go = Instantiate(_projectile, owner.transform.position, Quaternion.Euler(direction - owner.transform.position));
        go.GetComponent<Projectile>().Push(owner, direction, _projectileSpeed, _damage);
    }
}