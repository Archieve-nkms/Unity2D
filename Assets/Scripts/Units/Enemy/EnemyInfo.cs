using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Unit/Enemy", fileName = "Enemy_")]
public class EnemyInfo : ScriptableObject
{
    [Header("Texts")]
    [SerializeField]
    string _codeName;
    [SerializeField]
    string _displayName;

    [Header("Attributes")]
    [SerializeField]
    int _hp;
    [SerializeField]
    [Range(1, 20)]
    int _speed;
    [SerializeField]
    BaseWeapon _weapon;

    public string CodeName => _codeName;
    public string DisplayName => _displayName;
    public int HP => _hp;
    public int Speed => _speed;
    public BaseWeapon Weapon => _weapon;
}
