using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocar : MonoBehaviour
{


    void FixedUpdate()
    {
        Rigidbody rb = gameObject.GetComponent("Rigidbody") as Rigidbody;
        if (rb.IsSleeping()) {
            rb.WakeUp();
        }
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("a");
    }
}
