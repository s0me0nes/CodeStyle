using UnityEngine;

public class PointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _points;
    private Vector3 _currentTarget;
    private int _targetIndex = 0;

    void Start()
    {
        _points = GetComponentsInChildren<Transform>();
        _currentTarget = _points[_targetIndex].transform.position;
    }

    public void Update()
    {
        if (_currentTarget == null) return;

        if (transform.position == _currentTarget)
        {
            GetNextTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    public Vector3 GetNextTarget()
    {
        if (_targetIndex == _points.Length)
        {
            _targetIndex = 0;
        }

        _targetIndex++;
        _currentTarget = _points[_targetIndex].transform.position;
    
        return _currentTarget;
    }
}