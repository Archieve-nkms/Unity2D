using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField]
    GameObject _pointer;

    private void FixedUpdate()
    {
        UpdateRotation();
    }

    public void UpdateRotation()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (targetPosition - _pointer.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        _pointer.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}