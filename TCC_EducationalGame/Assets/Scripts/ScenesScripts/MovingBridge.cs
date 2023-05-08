using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float _checkDistance = 0.05f;
    private Transform _targetWaypoint;
    private int _currentWaypointIndex = 0;
    private Transform _originalParent;

    void Start()
    {
        _targetWaypoint = _waypoints[0];
        _originalParent = transform.parent;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _targetWaypoint.position,
            speed * Time.deltaTime
            );

        if (Vector2.Distance(transform.position, _targetWaypoint.position) < _checkDistance)
        {
            _targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }
        return _waypoints[_currentWaypointIndex];
    }
}