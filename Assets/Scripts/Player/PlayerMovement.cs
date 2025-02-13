using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private InputActionReference _moveActions;
	[SerializeField] private float _speed;

	private void Update()
	{
		var moveInputs = _moveActions.action.ReadValue<Vector2>();
		var direction = transform.forward * moveInputs.y + transform.right * moveInputs.x;
		direction = direction.normalized;
		_controller.SimpleMove(direction * _speed);
	}
}
