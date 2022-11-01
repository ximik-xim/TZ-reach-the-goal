using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class SpawnEntity : Fabric<Entity>
{
    [SerializeField] [Range(0.1f,100)] [Tooltip("В секундах")]
    private float _timeSpawn;
    [SerializeField] [Range(0.1f,100)] [Tooltip("В секундах")]
    private float _travelTime;
    [SerializeField] 
    private Transform _target;
    
    private void Start()
    {
        StartTimerSpawn();
    }

    public void UpdateTimeSpawnAndTravelTime(float timeSpawn,float travelTime)
    {
        _timeSpawn = timeSpawn;
        _travelTime = travelTime;
    }
    private async Task StartTimerSpawn()
    {
        await Task.Delay((int) (_timeSpawn * 1000));
        Entity entity = Spawn(transform.position);

        Tween tween = entity.transform.DOMove(_target.position, _travelTime).SetEase(Ease.Linear);
        tween.onComplete += () => entity.gameObject.SetActive(false);

        StartTimerSpawn();
    }
    

}
