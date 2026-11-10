using UnityEngine;

public class ThiefSpawner : MonoBehaviour
{
    [SerializeField] private Thief _thiefPrefab;
    [SerializeField] private ThiefTargetPoint _thiefTargetPoint;

    [SerializeField, Min(0)] private float _minThiefMoveSpeed;
    [SerializeField, Min(0)] private float _maxThiefMoveSpeed;
    [SerializeField] private int _amountOfThieves;

    private void Start()
    {
        for (int i = 0; i < _amountOfThieves; ++i)
        {
            float thiefMoveSpeed = Random.Range(_minThiefMoveSpeed, _maxThiefMoveSpeed);

            var thief = Instantiate(_thiefPrefab);
            
            thief.Initialize(_thiefTargetPoint.transform.position, transform.position, thiefMoveSpeed);
            thief.transform.position = transform.position;
        }
    }

    private void OnValidate()
    {
        if (_minThiefMoveSpeed > _maxThiefMoveSpeed)
            _minThiefMoveSpeed = _maxThiefMoveSpeed;
    }
}
