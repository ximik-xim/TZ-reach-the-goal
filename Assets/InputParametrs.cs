using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InputParametrs : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> _updateTargetPosition;
    [SerializeField] private UnityEvent<float, float> _updateTimeSpawnAndTravelTime;
   
    private float _minValue = 0.1f;
    private Vector3 _targetPosition = new Vector3(10, 1, 1);
    private float _timeSpawn = 1f;
    private float _travelTime = 3f;

    private void Start()
    {
        _updateTargetPosition.Invoke(_targetPosition);
        _updateTimeSpawnAndTravelTime.Invoke(_timeSpawn,_travelTime);
    }

    public void UpdateValueTargetX(string str)
    {
        _targetPosition.x = CheckValue(Convert(str)); 
        _updateTargetPosition.Invoke(_targetPosition);
    }
    public void UpdateValueTargetY(string str)
    {
        _targetPosition.y = CheckValue(Convert(str)); 
        _updateTargetPosition.Invoke(_targetPosition);
    }
    public void UpdateValueTargetZ(string str)
    {
        _targetPosition.z = CheckValue(Convert(str)); 
        _updateTargetPosition.Invoke(_targetPosition);
    }

    public void UpdateValueTimeSpawn(string str)
    {
        _timeSpawn = CheckValue(Convert(str));
        _updateTimeSpawnAndTravelTime.Invoke(_timeSpawn,_travelTime);
    }
    
    public void UpdateValueTravelTime(string str)
    {
        _travelTime = CheckValue(Convert(str));
        _updateTimeSpawnAndTravelTime.Invoke(_timeSpawn,_travelTime);
    }

    private float CheckValue(float value)
    {
        if (value < _minValue)
        {
            return _minValue;
        }

        return value;
    }
    private float Convert(string str)
    {
        if (str != "") 
        {
            return float.Parse(str);    
        }
        return _minValue;
    }
}
