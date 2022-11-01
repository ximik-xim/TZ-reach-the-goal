using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class Fabric<T> : MonoBehaviour where T : Entity
{
    [SerializeField] protected T _entity;
    [SerializeField] protected Pool<T> _pool = new Pool<T>();

    protected virtual Entity Spawn(Vector3 spawnPosition)
    {
        Entity entity;
        if (_pool.DisavleObject.Count > 0)
        {
            entity = _pool.DisavleObject[0];
            
            entity.gameObject.SetActive(true);
            entity.transform.position = spawnPosition;
            
            return entity;
        }

        entity = Create();
        return entity;
    }
    
    protected virtual Entity Create()
    {
        T prefabEntity = _entity;
                    
        Entity entity = InstantiatePrefabe(prefabEntity);

        return entity;
    }

    private Entity InstantiatePrefabe(T prefabEntity)
    {
        Entity entity = Instantiate(prefabEntity, Vector3.zero, Quaternion.identity);
        entity.transform.parent = transform;
        entity.gameObject.SetActive(true);
        _pool.EnableObject.Add((T) entity);
        entity.CreateEntity(UpdatePool);
        
        return entity;
    }

    protected void UpdatePool(bool activeObject,MonoBehaviour monoBehaviour)
    {
        T entity = monoBehaviour as T;  
       
        if (activeObject == true)
        {
            _pool.DisavleObject.Remove(entity);
            _pool.EnableObject.Add(entity);
            return;
        }
       
        _pool.EnableObject.Remove(entity);
        _pool.DisavleObject.Add(entity);
    }
}
