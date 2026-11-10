using UnityEngine;

public class ThiefSpawner : MonoBehaviour
{
    [SerializeField] private Thief _thiefPrefab;
    [SerializeField] private ThiefTargetPoint[] _thiefTargetPoints;

    [SerializeField, Min(0)] private float _minThiefMoveSpeed;
    [SerializeField, Min(0)] private float _maxThiefMoveSpeed;
    [SerializeField, Min(0)] private int _amountOfThieves;

    private void Start()
    {
        for (int i = 0; i < _amountOfThieves; ++i)
        {
            float thiefMoveSpeed = Random.Range(_minThiefMoveSpeed, _maxThiefMoveSpeed);

            Thief thief = Instantiate(_thiefPrefab, transform.position, Quaternion.identity);
            
            thief.Initialize(_thiefTargetPoints, thiefMoveSpeed);
        }
    }

    private void OnValidate()
    {
        if (_minThiefMoveSpeed > _maxThiefMoveSpeed)
            _minThiefMoveSpeed = _maxThiefMoveSpeed;
    }
}
