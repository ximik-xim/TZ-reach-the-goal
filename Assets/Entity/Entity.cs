using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    private event Action<bool, MonoBehaviour> _enable;
 
    public void CreateEntity(Action<bool,MonoBehaviour> action)
    {
        _enable += action;
    }
 
    protected virtual void OnEnable()
    {
        _enable?.Invoke(true,this);
    }
    
    protected virtual void OnDisable()
    {
        _enable?.Invoke(false, this);
    }
 
}
