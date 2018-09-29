using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float MaxSpeed = 8.0f;
    [SerializeField] private float _speed = 5;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void AssignMovementAngle(float angle)
    {
        _rb.velocity =  Quaternion.AngleAxis(angle, Vector3.forward) * new Vector2(_speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var playerController = col.GetComponent<PlayerController>();
            var axis = playerController.GetMovementAxis();

            if (_speed < MaxSpeed)
            {
                _speed = Math.Min(_speed + 0.3f, MaxSpeed);
            }

            var newX = -Math.Sign(_rb.velocity.x) * _speed;
            var newY = Math.Sign(_rb.velocity.y * _speed) + axis * _speed;

            _rb.velocity = new Vector2(newX, newY);
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -_rb.velocity.y);
        }
    }
}