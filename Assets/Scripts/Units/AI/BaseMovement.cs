using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected Transform _owner;
    protected Vector2 _destPos;
    protected float _speed;

    public virtual void SetUp(Transform owner, Vector2 destPos, float speed)
    {
        _owner = owner;
        _speed = speed;
        SetDestination(destPos);
    }

    public virtual void SetDestination(Vector2 destPos)
    {
        _destPos = destPos;
    }

    public abstract void Move();
}