using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypontsParent;

    private Transform[] _checkpoints;
    private Transform _waypoint;
    private int _currentWaypoint = 0;

    void Start()
    {
        _checkpoints = new Transform[_waypontsParent.childCount];

        for (int i = 0; i < _waypontsParent.childCount; i++)
        {
            _checkpoints[i] = _waypontsParent.GetChild(i);
        }

        _waypoint = _checkpoints[_currentWaypoint];
    }

    public void Update()
    {
        if (transform.position == _checkpoints[_currentWaypoint].position)
        {
            UpdateWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed * Time.deltaTime);
    }

    public void UpdateWaypoint()
    {
        _currentWaypoint = ++_currentWaypoint % _checkpoints.Length;
        _waypoint = _checkpoints[_currentWaypoint];
    }
}
