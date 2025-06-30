using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// initial....
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _screenBorder;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;
    private PlayerShoot _playerShoot;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _playerShoot = GetComponent<PlayerShoot>();
    }
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotationInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
          _smoothedMovementInput,
          _movementInput,
          ref _movementInputSmoothVelocity,
          0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;

        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);
        
        if((screenPosition.x < _screenBorder && _rigidbody.velocity.x<0) || 
            (screenPosition.x> _camera.pixelWidth- _screenBorder && _rigidbody.velocity.x>0) )
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if((screenPosition.y < _screenBorder && _rigidbody.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight- _screenBorder && _rigidbody.velocity.y > 0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,0);
        }
    }

    private void RotationInDirectionOfInput()
    {
        // Only rotate based on movement if not currently aiming/shooting with mouse
        if(_movementInput != Vector2.zero && _playerShoot != null && !_playerShoot.IsRotatingToMouse())
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rigidbody.MoveRotation(rotation);
        }
    }
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
