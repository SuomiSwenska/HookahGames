﻿using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private Transform cameraParentTransform;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;

    private float firstClickPositionX;
    private bool isDragging = false;
    private Vector2 lastTouchPos;
    private bool _isMoved;
    private bool _isMouseButtonDown;
    private bool _isPrevMouseButtonDown;
    private bool _isReadyToRrotate;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.OnInput += MovedState;
        _playerInput.OnStopInput += NotMovedState;
    }

    private void OnDisable()
    {
        _playerInput.OnInput -= MovedState;
        _playerInput.OnStopInput -= NotMovedState;
    }

    private void Update()
    {
        MouseInputHandler();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(_isMoved ? 1 : 0);

                if (touch.position.x >= Screen.width * 0.5f)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        isDragging = true;
                        lastTouchPos = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Moved && isDragging)
                    {
                        float rotationY = -(touch.position.x - lastTouchPos.x) * rotationSpeed * Time.deltaTime;

                        RotateCamera(rotationY);

                        lastTouchPos = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        isDragging = false;
                    }
                }
            }
            //else
            //{
            //    float rotationY = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            //    RotateCamera(rotationY);
            //}
        }
    }

    private void MovedState(Vector3 direction)
    {
        _isMoved = true;
    }

    private void NotMovedState()
    {
        _isMoved = false;
    }

    private void MouseInputHandler()
    {
        _isMouseButtonDown = Input.GetMouseButton(0);

        if (_isMouseButtonDown && !_isPrevMouseButtonDown && Input.mousePosition.x >= Screen.width * 0.5f)
        {
            firstClickPositionX = Input.GetAxis("Mouse X");
            _isReadyToRrotate = true;
        }

        if (_isMouseButtonDown && _isReadyToRrotate)
        {
            float rotationY = (firstClickPositionX + Input.GetAxis("Mouse X")) * rotationSpeed * Time.deltaTime;

            RotateCamera(rotationY);
        }

        if (!_isMouseButtonDown) _isReadyToRrotate = false;
        _isPrevMouseButtonDown = _isMouseButtonDown;
    }


    private void RotateCamera(float y)
    {
        cameraParentTransform.Rotate(0, y, 0);
    }
}