using System;
using System.Collections.Generic;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    private HashSet<Thief> _thieves = new HashSet<Thief>();

    public event Action<int> ThiefEnter;
    public event Action<int> ThiefExit; 

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out var thief) && _thieves.Contains(thief) == false)
        {
            _thieves.Add(thief);
            ThiefEnter?.Invoke(_thieves.Count);
        }
    }
    
    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out var thief))
        {
            _thieves.Remove(thief);
            ThiefExit?.Invoke(_thieves.Count);
        }
    }
}
