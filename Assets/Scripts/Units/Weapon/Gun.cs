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
    [Range(1, 10)]
    float _projectileSpeed;

    public int ProjectileAmount => _projectileAmount;
    public float ProjectileSpeed => _projectileSpeed;

    public override void Fire(BaseUnit owner, Vector3 direction, out float nextFireTick)
    {
        nextFireTick = Time.time + _firerate;

        GameObject bullet = Managers.Pool.GetInstance(_projectile);
        bullet.transform.position = owner.transform.position;
        bullet.transform.rotation = Quaternion.Euler(direction - owner.transform.position);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        bullet.GetComponent<Projectile>().Push(owner, direction, _projectileSpeed, _damage);
    }
}