using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RouteType
{
	OneWay,
	PingPong,
	Loop
}

public class NavigationRoute : MonoBehaviour
{
	[SerializeField] private Color _color = Color.white;
	[SerializeField] private RouteType _routeType = RouteType.OneWay;
	[SerializeField] private Waypoint[] _waypoints;

	public int WaypointCount => _waypoints?.Length ?? 0;
	public Vector3 this[int index] => _waypoints[index].transform.position;

	[ContextMenu("Collect waypoints")]
	private void CollectWaypoints() => _waypoints = GetComponentsInChildren<Waypoint>();

	private void OnDrawGizmos()
	{
		if (_waypoints == null) return;
		Gizmos.color = _color;
		var offset = Vector3.up * 0.01f;
		for (int i = 0; i < _waypoints.Length - 1; i++)
		{
			Gizmos.DrawLine(_waypoints[i].transform.position + offset, _waypoints[i + 1].transform.position + offset);
		}
		if (_routeType == RouteType.Loop)
		{
			Gizmos.DrawLine(_waypoints[^1].transform.position + offset, _waypoints[0].transform.position + offset);
		}
	}
}
