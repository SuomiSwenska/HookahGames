using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _rocketPrefab;

    private List<GameObject> _enemies;
    private List<GameObject> _usedEnemies;

    private List<GameObject> _rockets;
    private List<GameObject> _usedRockets;

    private void Awake()
    {
        _enemies = new List<GameObject>();
        _usedEnemies = new List<GameObject>();
        _rockets = new List<GameObject>();
        _usedRockets = new List<GameObject>();
    }

    private void Start()
    {
        CreateObjects();
    }

    private void CreateObjects()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject rocket = Instantiate(_rocketPrefab, Vector3.zero, Quaternion.identity);
            rocket.SetActive(false);
            _rockets.Add(rocket);
        }
    }

    public GameObject GetRocket()
    {
        GameObject rocketGO = _rockets[0];
        _rockets.RemoveAt(0);
        rocketGO.SetActive(true);
        _usedRockets.Add(rocketGO);
        return rocketGO;
    }

    public GameObject GetEnemyGO()
    {
        GameObject enemyGO = _enemies[0];
        _enemies.RemoveAt(0);
        enemyGO.SetActive(true);
        _usedEnemies.Add(enemyGO);
        return enemyGO;
    }

    public void AddEnemyToPool(GameObject enemyGO)
    {
        _enemies.Add(enemyGO);
        if (_usedEnemies.Contains(enemyGO)) _usedEnemies.Remove(enemyGO);
        enemyGO.SetActive(false);
    }

    public void AddRocketToPool(GameObject rocketGO)
    {
        _rockets.Add(rocketGO);
        if (_usedRockets.Contains(rocketGO)) _usedRockets.Remove(rocketGO);
        rocketGO.SetActive(false);
        rocketGO.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
