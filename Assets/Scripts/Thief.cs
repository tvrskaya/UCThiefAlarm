using UnityEngine;

public class Thief : MonoBehaviour
{
    private ThiefTargetPoint[] _movePoints;
    private int _currentPointIndex;

    private float _moveSpeed;

    private void Update()
    {
        UpdateCurrentTargetPoint();
        Move();
    }

    public void Initialize(ThiefTargetPoint[] movePoints, float moveSpeed)
    {
        _movePoints = movePoints;
        _moveSpeed = moveSpeed;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                _movePoints[_currentPointIndex].transform.position,
                                                _moveSpeed * Time.deltaTime);
    }

    private void UpdateCurrentTargetPoint()
    {
        if (transform.position == _movePoints[_currentPointIndex].transform.position)
        {
            ++_currentPointIndex;
            _currentPointIndex %= _movePoints.Length;
        }
    }
}
