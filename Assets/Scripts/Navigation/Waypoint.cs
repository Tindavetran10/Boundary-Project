using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	[SerializeField] private Color _color = Color.white;

	private void OnDrawGizmos()
	{
		Gizmos.color = _color;
		Gizmos.DrawSphere(transform.position, 0.1f);
	}
}
