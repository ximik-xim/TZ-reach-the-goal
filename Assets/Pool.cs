using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Pool<T>
{
    public Pool()
    {
        EnableObject = new List<T>();
        DisavleObject = new List<T>();
    }
    public List<T> EnableObject;
    public List<T> DisavleObject;
}
