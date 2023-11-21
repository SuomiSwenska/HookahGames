using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private PlayerInput _playerInput;

    public float rotationSpeed = 2.0f;

    private bool isDragging = false;
    private Vector2 lastTouchPos;

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private bool _isMoved;

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

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;


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
            else
            {
                float rotationY = -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

                RotateCamera(rotationY);
            }
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


    private void RotateCamera(float y)
    {
        transform.Rotate(0, y, 0);
    }
}