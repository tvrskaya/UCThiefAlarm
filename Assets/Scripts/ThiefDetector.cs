using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefExited; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            ThiefEntered?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            ThiefExited?.Invoke();
    }
}
