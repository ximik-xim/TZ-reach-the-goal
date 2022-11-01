using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnd : MonoBehaviour
{
   public void UpdatePosition(Vector3 newPosition)
   {
      transform.position = newPosition;
   }
}
