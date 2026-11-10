using UnityEngine;

public class Thief : MonoBehaviour
{
    private Vector3 _targetPoint;
    private Vector3 _returnPoint;
    private Vector3 _currentTargetPoint;

    private float _moveSpeed;

    public void Initialize(Vector3 targetPoint, Vector3 returnPoint, float moveSpeed)
    {
        _targetPoint = targetPoint;
        _currentTargetPoint = targetPoint;
        _returnPoint = returnPoint;
        _moveSpeed = moveSpeed;
    }

    private void Update()
    {
        UpdateCurrentTargetPoint();
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                _currentTargetPoint,
                                                _moveSpeed * Time.deltaTime);
    }
    
    private void UpdateCurrentTargetPoint()
    {
        if (transform.position == _targetPoint)
            _currentTargetPoint = _returnPoint;
        else if (transform.position == _returnPoint)
            _currentTargetPoint = _targetPoint;
    }
}
