using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    float _speed = 10f;

    bool _canMove = true;
    Rigidbody2D _rigidBody;
    Vector2 _movement;

    public float Speed => _speed;
    public bool CanMove => _canMove;
    public Vector2 Movement => _movement;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        if (_canMove)
            UpdateMovement();
    }

    public void GetInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    public void UpdateMovement()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * _speed * Time.fixedDeltaTime);
    }
}