using UnityEngine;

public class House : MonoBehaviour
{
    private const int ThievesToActivateAlarm = 1;
    private const int ThievesToDeactivateAlarm = 0;

    [SerializeField] private ThiefDetector _thiefDetector;
    [SerializeField] private Alarm _alarm;

    private int _thievesInside;

    private void OnEnable()
    {
        _thiefDetector.ThiefEntered += ProcessThiefEntered;
        _thiefDetector.ThiefExited += ProcessThiefExited;
    }

    private void OnDisable()
    {
        _thiefDetector.ThiefEntered -= ProcessThiefEntered;
        _thiefDetector.ThiefExited -= ProcessThiefExited;
    }

    private void ProcessThiefEntered()
    {
        ++_thievesInside;

        if (_thievesInside == ThievesToActivateAlarm)
            _alarm.Activate();
    }

    private void ProcessThiefExited()
    {
        --_thievesInside;

        if (_thievesInside == ThievesToDeactivateAlarm)
            _alarm.Deactivate();
    }
}
