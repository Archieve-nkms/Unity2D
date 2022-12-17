using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : BaseMovement
{
    float _distance;
    float _curdistance;

    public override void SetValue(int value)
    {
        _distance = value;
    }

    public override void Move()
    {
        Vector3 dir = (Vector2)(_owner.position - _destPos).normalized;
        _curdistance = Vector3.Distance(_owner.position, _destPos);

        if (Mathf.Abs(_curdistance) - _distance > 1.25f) 
        {
            _ownerRigidbody.MovePosition(_owner.position - dir * _speed * Time.deltaTime);
        }
        else if(Mathf.Abs(_curdistance) - _distance < 0.75f)
        {
            _ownerRigidbody.MovePosition(_owner.position + dir * _speed * Time.deltaTime);
        }

    }
}