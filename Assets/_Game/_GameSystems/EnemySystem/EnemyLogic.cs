using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private PlayerSystem _playerSystem;
    [SerializeField] private List<Enemy> enemies;

    private bool _isAttack;

    private void Awake()
    {
        _playerSystem = FindObjectOfType<PlayerSystem>();
    }

    private void OnEnable()
    {
        _playerSystem.OnPlayerShoot += PlayerShootingHandler;
    }

    private void OnDisable()
    {
        _playerSystem.OnPlayerShoot -= PlayerShootingHandler;
    }

    private void PlayerShootingHandler()
    {
        if (_isAttack) return;
        foreach (var item in enemies)
        {
            item.StartPursue();
        }
        _isAttack = true;
    }
}
