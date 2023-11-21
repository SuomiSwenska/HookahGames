using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireLogic : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerSystem _playerSystem;
    private Player _player;

    private bool _isFired;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerSystem = FindObjectOfType<PlayerSystem>();

        _player = _playerSystem.playerGO.GetComponent<Player>();
    }

    private void OnEnable()
    {
        _playerInput.OnFireButtonDown += Fire;
    }

    private void OnDisable()
    {
        _playerInput.OnFireButtonDown -= Fire;
    }

    private void Fire()
    {
        if (_isFired) return;

        StartCoroutine(FireDelay());
    }

    private IEnumerator FireDelay()
    {
        _isFired = true;
        _playerSystem.OnPlayerShoot?.Invoke();
        _player.RocketLaunch();
        yield return new WaitForSeconds(_playerSystem.fireDelay);
        _isFired = false;
    }
}
