using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLogic : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerSystem _playerSystem;

    private Rigidbody _playerRb;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerSystem = FindObjectOfType<PlayerSystem>();

        _playerRb = _playerSystem.playerGO.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInput.OnInput += PlayerMove;
    }

    private void OnDisable()
    {
        _playerInput.OnInput -= PlayerMove;
    }

    private void PlayerMove(Vector3 direction)
    {
        Vector3 nextPosition = Vector3.Lerp(_playerRb.transform.position, _playerRb.transform.position += direction * _playerSystem.palyerSpeed, Time.deltaTime);
        _playerRb.MovePosition(nextPosition);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _playerRb.transform.rotation = Quaternion.Lerp(_playerRb.transform.rotation, lookRotation, Time.deltaTime * _playerSystem.rotationLerpFactor);
    }
}
