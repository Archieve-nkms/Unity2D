using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : BaseMovement
{
    float _radius;
    float _additionalOffsetValue;
    float _offset;

    private void Start()
    {
        _additionalOffsetValue = Random.Range(1f, 50f);
    }

    public override void SetValue(int value)
    {
        _radius = value;
    }

    public override void Move()
    {
        _offset = Time.time * _speed/5 + _additionalOffsetValue;
       // _owner.position = _destPos + new Vector3(Mathf.Sin(_offset), Mathf.Cos(_offset)) * _radius;
        _ownerRigidbody.MovePosition(_destPos + new Vector3(Mathf.Sin(_offset), Mathf.Cos(_offset)) * _radius);
    }
}