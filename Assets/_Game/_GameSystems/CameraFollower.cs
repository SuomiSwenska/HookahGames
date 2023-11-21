using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    private bool isDragging = false;
    private Vector2 lastTouchPos;

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;


            //// Проверяем, есть ли касание экрана (для мобильных устройств)
            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);

            //    // Проверяем, находится ли касание в левой части экрана
            //    if (touch.position.x < Screen.width * 0.5f)
            //    {
            //        if (touch.phase == TouchPhase.Began)
            //        {
            //            isDragging = true;
            //            lastTouchPos = touch.position;
            //        }
            //        else if (touch.phase == TouchPhase.Moved && isDragging)
            //        {
            //            // Вычисляем величину свайпа по вертикали и горизонтали
            //            float rotationX = (touch.position.y - lastTouchPos.y) * rotationSpeed * Time.deltaTime;
            //            float rotationY = -(touch.position.x - lastTouchPos.x) * rotationSpeed * Time.deltaTime;

            //            // Поворачиваем камеру в соответствии с величиной свайпа
            //            RotateCamera(rotationX, rotationY);

            //            lastTouchPos = touch.position;
            //        }
            //        else if (touch.phase == TouchPhase.Ended)
            //        {
            //            isDragging = false;
            //        }
            //    }
            //}
            //else
            //{
            //    // Если не используется тач-экран, проверяем ввод с мыши
            //    float rotationX = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            //    float rotationY = -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            //    // Поворачиваем камеру в соответствии с величиной ввода с мыши
            //    RotateCamera(rotationX, rotationY);
            //}
        }
    }

    private void RotateCamera(float x, float y)
    {
        // Поворачиваем камеру вокруг осей X и Y
        transform.Rotate(x, y, 0);
    }
}