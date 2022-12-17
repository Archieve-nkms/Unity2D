using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected Rigidbody2D _ownerRigidbody;
    protected Transform _owner;
    protected Vector3 _destPos;
    protected float _speed;

    public virtual void SetUp(Transform owner, Vector3 destPos, float speed, int value)
    {
        _owner = owner;
        _ownerRigidbody = owner.GetComponent<Rigidbody2D>();
        _speed = speed;
        SetDestination(destPos);
        SetValue(value);
    }

    public virtual void SetDestination(Vector2 destPos)
    {
        _destPos = destPos;
    }

    public abstract void SetValue(int value);

    public abstract void Move();
}