using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _meshAgent;
    [SerializeField] private float _destroyDelay;
    [SerializeField] private GameObject _explosionEffect;
    public Transform playerTransform;

    private void Awake()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
    }

    public void Init()
    {
        
    }

    public void StartPursue()
    {
        StartCoroutine(StartPursuevCoroutineCicle());
    }

    private IEnumerator StartPursuevCoroutineCicle()
    {
        while (true)
        {
            _meshAgent.SetDestination(playerTransform.position);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Rocket") Death();
    }

    private void Death()
    {
        StopAllCoroutines();
        _meshAgent.enabled = false;
        GetComponent<Rigidbody>().AddForce((-transform.forward + transform.up * 2) * 5f, ForceMode.Impulse);
        _explosionEffect.SetActive(true);
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_destroyDelay);
        Destroy(gameObject);
    }
}
