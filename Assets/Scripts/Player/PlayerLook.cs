using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private InputActionReference _lookActions;
    [SerializeField] private float _anglePerSeconds;

    private void Update()
    {
        var lookInputs = _lookActions.action.ReadValue<float>();
        transform.Rotate(0, lookInputs * _anglePerSeconds * Time.deltaTime, 0);
    }
}
