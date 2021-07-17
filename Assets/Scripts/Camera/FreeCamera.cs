using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Storages;
using Game.PlayerInput;

public class FreeCamera : MonoBehaviour
{
    private float _speed = 40f;
    private const float _rotationAngle = 20f;
    private const float _minCameraSize = 10f;
    private const float _maxCameraSize = 20f;
    private const float _cameraZoomMultiplyer = -7; //negative to zoomin on mousewheelup, positive to zoomin on mousewheeldown
    private const float _defaultSpeed = 40;
    private const float _fastSpeed = 80;
    private Vector3 _targetVelocity;

    private Camera _camera;
    private Rigidbody _cameraRigidbody;

    private CameraInput _input;

    private void Awake()
    {
        _input = new CameraInput();
    }

    private void Start()
    {
        _camera = Storages.GameData.Camera.GetFirstItem();
        _cameraRigidbody = _camera.GetComponent<Rigidbody>();
        _camera.orthographicSize = _minCameraSize;
        _camera.transform.localEulerAngles = (new Vector3(_rotationAngle, 0, 0));
    }

    private void Update()
    {
        _input.UpdateInput();
        ZoomCamera();
    }

    private void FixedUpdate()
    {
        MoveCamera();
        SpeedUp();


    }

    private void MoveCamera()
    {
        _targetVelocity.x = _speed * _input.Movement.x;
        _targetVelocity.z = _speed * _input.Movement.y;
        _targetVelocity.y = 0;
        _cameraRigidbody.velocity = _targetVelocity;
    }

    private void ZoomCamera()
    {
        var newSize = _camera.orthographicSize + _input.MouseScrollDelta * _cameraZoomMultiplyer;
        _camera.orthographicSize = Mathf.Clamp(newSize, _minCameraSize, _maxCameraSize);
    }

    private void SpeedUp()
    {
        if (_input.ShiftHolding)
        {
            _speed = _fastSpeed;
        } else
        {
            _speed = _defaultSpeed;
        }
    }



    
}
