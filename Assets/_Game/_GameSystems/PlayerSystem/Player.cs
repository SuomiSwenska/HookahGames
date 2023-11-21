using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _rocketPoint;
    [SerializeField] private float _rocketForce;

    private ObjectsPool _objectsPool;
    private Rigidbody[] _ragdollRigidbodies;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _objectsPool = FindObjectOfType<ObjectsPool>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    public void Death()
    {
        ActivateRagdoll();
    }

    private void DisableRagdoll()
    {
        foreach (var rb in _ragdollRigidbodies)
        {
            if (rb == _rigidbody) continue;
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
    }

    private void ActivateRagdoll()
    {
        GetComponent<Animator>().enabled = false;

        foreach (var rb in _ragdollRigidbodies)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }

        _rigidbody.isKinematic = true;
        _rigidbody.detectCollisions = false;
        GetComponent<Collider>().enabled = false;

        GetComponent<Rigidbody>().AddForce(-transform.forward * 350, ForceMode.Impulse);
    }

    public void RocketLaunch()
    {
        GameObject rocket = _objectsPool.GetRocket();
        rocket.transform.position = _rocketPoint.position;
        rocket.transform.rotation = _rocketPoint.rotation;

        rocket.GetComponent<Rigidbody>().AddForce(_rocketForce * rocket.transform.forward, ForceMode.Impulse);
        rocket.GetComponent<Rocket>().InitRocket();
    }
}
