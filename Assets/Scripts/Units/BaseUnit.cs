using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour, IDamageable
{
    protected Faction _faction;
    protected int _currenthp;

    protected float _nextFireTick = 0f;

    public Faction Faction => _faction;
    public int CurrentHp => _currenthp;
    public bool IsDead => _currenthp <= 0;
    public bool CanFire => Time.time >= _nextFireTick;

    protected abstract void OnDead();
    
    public virtual void TakeDamage(int amount)
    {
        _currenthp -= amount;

        Debug.Log($"Got {amount} Damage");

        if (IsDead)
            OnDead();
    }
}
