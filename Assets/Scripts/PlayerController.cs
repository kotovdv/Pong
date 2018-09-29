using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 8.0f;
    [SerializeField] private Player _player;


    private Rigidbody2D _rb;
    private readonly Dictionary<Direction, bool> _isMovementAllowed = new Dictionary<Direction, bool>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _isMovementAllowed[Direction.Up] = true;
        _isMovementAllowed[Direction.Down] = true;
    }

    private void Update()
    {
        var isUpwardMovementAllowed = _isMovementAllowed[Direction.Up];
        var isDownwardMovementAllowed = _isMovementAllowed[Direction.Down];

        var axis = GetMovementAxis();

        var axisSign = Math.Sign(axis);
        if (axisSign == 0) return;

        var movementAllowed = axisSign > 0
            ? isUpwardMovementAllowed
            : isDownwardMovementAllowed;

        if (movementAllowed)
        {
            _rb.MovePosition(_rb.position + new Vector2(0, axis * Speed * Time.deltaTime));
        }
    }

    public float GetMovementAxis()
    {
        return Input.GetAxis("VerticalP" + (int) _player);
    }

    public void SetMovementLockedState(Direction direction, bool state)
    {
        _isMovementAllowed[direction] = state;
    }
}