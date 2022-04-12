using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
   

     void LateUpdate()
    {
        
        transform.position = Vector3.Lerp(transform.position, target.position, 1);
    }
}
