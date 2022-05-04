using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocar : MonoBehaviour
{


    void OnCollisionEnter(Collision collisionInfo)
    {
        Collider col = collisionInfo.collider;

        if (col.CompareTag("Player") ){
            //Debug.Log("dale");
        }
    }
}
