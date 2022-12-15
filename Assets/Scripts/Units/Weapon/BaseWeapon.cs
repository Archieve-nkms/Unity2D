using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : ScriptableObject
{
    [Header("Texts")]
    [SerializeField]
    protected string _codeName;
    [SerializeField]
    protected string _displayName;

    [Header("Attributes")]
    [SerializeField]
    protected int _damage;
    [SerializeField]
    [Range(0.01f, 5f)]
    protected float _firerate;

    public string CodeName => _codeName;
    public string DisplayName => _displayName;
    public int Damage => _damage;
    public float Firerate => _firerate;

    public abstract void Fire(BaseUnit owner, Vector3 direction, out float nextFireTick);
}