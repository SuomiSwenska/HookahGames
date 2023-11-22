using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParentFollower : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * 10);
    }
}
