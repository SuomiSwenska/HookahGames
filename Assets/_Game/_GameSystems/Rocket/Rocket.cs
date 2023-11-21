using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private ObjectsPool _objectsPool;

    private void Awake()
    {
        _objectsPool = FindObjectOfType<ObjectsPool>();
    }

    public void InitRocket()
    {
        StartCoroutine(RocketDestoryDelay());
    }

    private IEnumerator RocketDestoryDelay()
    {
        yield return new WaitForSeconds(3);
        _objectsPool.AddRocketToPool(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopAllCoroutines();
        _objectsPool.AddRocketToPool(gameObject);
    }
}
