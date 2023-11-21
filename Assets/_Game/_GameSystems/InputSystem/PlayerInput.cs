using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<Vector3> OnInput;
    public Action OnStopInput;
    public Action OnFireButtonDown;

    [SerializeField] private float _trashholdInput;
    [SerializeField] private bl_Joystick _bl_Joystick;

    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        Vector3 direction = new Vector3(_bl_Joystick.Horizontal, 0, _bl_Joystick.Vertical);

        if (direction.magnitude >= _trashholdInput) OnInput?.Invoke(direction);
        else OnStopInput?.Invoke();
    }

    public void FireButtonDown()
    {
        OnFireButtonDown?.Invoke();
    }
}
