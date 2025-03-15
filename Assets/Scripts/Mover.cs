using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypontsParent;
    [SerializeField] private Transform[] _checkpoints;

    private Transform _waypoint;
    private int _currentWaypoint = 0;

    private void Start()
    {
        if(_checkpoints.Length == 0)
        {
            RefreshChildArray();
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

    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _checkpoints = new Transform[_waypontsParent.childCount];

        for (int i = 0; i < _checkpoints.Length; i++)
        {
            _checkpoints[i] = _waypontsParent.GetChild(i);
        }
    }
}
