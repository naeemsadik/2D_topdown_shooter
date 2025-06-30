using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    [SerializeField]
    private float _rotationSpeed = 1440f; // Degrees per second for rotation

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;
    private Camera _camera;
    private Vector2 _mousePosition;
    private bool _shouldRotateToMouse = false;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        // Handle mouse input for shooting
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _shouldRotateToMouse = true;
            _fireSingle = true;
        }

        // Rotate towards mouse when shooting
        if (_shouldRotateToMouse)
        {
            RotateTowardsMouse();
        }

        // Fire bullet logic
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;
            if(timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
                _fireSingle = false;
                _shouldRotateToMouse = false; // Stop rotating after firing
            }       
        }
    }

    private void RotateTowardsMouse()
    {
        // Convert mouse screen position to world position
        Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, _camera.nearClipPlane));
        mouseWorldPos.z = transform.position.z; // Keep same Z position

        // Calculate direction from player to mouse
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // Calculate target rotation
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90 because Unity's up is different
        Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);

        // Smoothly rotate towards target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        // Check if rotation is close enough to target
        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            transform.rotation = targetRotation;
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }

    // Public method for PlayerMovement to check if mouse rotation is active
    public bool IsRotatingToMouse()
    {
        return _shouldRotateToMouse;
    }
}
