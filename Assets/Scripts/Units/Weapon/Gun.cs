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
    [SerializeField]
    [Range(0f, 0.5f)]
    float _spreadAngle = 0.0f;

    public int ProjectileAmount => _projectileAmount;
    public float ProjectileSpeed => _projectileSpeed;


    public override void Fire(BaseUnit owner, Vector3 direction, out float nextFireTick)
    {
        nextFireTick = Time.time + _firerate;

        for (int i = 0; i < _projectileAmount; i++)
        {
            GameObject bullet = Managers.Pool.GetInstance(_projectile);
            bullet.transform.position = owner.transform.position;
            bullet.transform.rotation = Quaternion.Euler(direction);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            float randomX = Random.Range(-_spreadAngle, _spreadAngle);
            float randomY = Random.Range(-_spreadAngle, _spreadAngle);
            Vector3 randomDir = new Vector3(randomX, randomY, 0);
            Vector3 dir = direction + randomDir;

            bullet.GetComponent<Projectile>().Push(owner, dir, _projectileSpeed, _damage);
        }
    }
}