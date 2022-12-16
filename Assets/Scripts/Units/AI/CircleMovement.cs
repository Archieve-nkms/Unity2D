using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : BaseMovement
{
    [SerializeField]
    float _radius;
    float _additionalOffsetValue;
    float _offset;

    private void Start()
    {
        _additionalOffsetValue = Random.Range(1f, 50f);
    }

    public override void Move()
    {
        _offset = Time.time * _speed + _additionalOffsetValue;
        _owner.position = _destPos + new Vector2(Mathf.Sin(_offset), Mathf.Cos(_offset)) * _radius;
    }
}