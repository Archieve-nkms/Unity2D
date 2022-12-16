using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    Faction _ownerFaction = Faction.None;
    int _damage;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseUnit target = collision.GetComponent<BaseUnit>();
        if (target != null)
        {
            if (_ownerFaction == Faction.None ||
                _ownerFaction == Faction.Ally && target is Enemy ||
                _ownerFaction == Faction.Enemy && target is Player)
            {
                target.TakeDamage(_damage);

                this.gameObject.SetActive(false);
            }

        }
    }

    public void Push(BaseUnit owner, Vector3 direction, float speed, int damage)
    {
        _ownerFaction = owner.Faction;
        _damage = damage;

        _spriteRenderer.color = owner.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }
}