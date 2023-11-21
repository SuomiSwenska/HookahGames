using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationLogic : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerSystem _playerSystem;
    private Animator _playerAnimator;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerSystem = FindObjectOfType<PlayerSystem>();

        _playerAnimator = _playerSystem.playerGO.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.OnInput += AnimationPlay;
        _playerInput.OnStopInput += AnimationPlayStop;
    }

    private void OnDisable()
    {
        _playerInput.OnInput -= AnimationPlay;
        _playerInput.OnStopInput -= AnimationPlayStop;
    }

    private void AnimationPlay(Vector3 direction)
    {
        _playerAnimator.SetBool("IsWalk", true);
    }

    private void AnimationPlayStop()
    {
        _playerAnimator.SetBool("IsWalk", false);
    }
}
