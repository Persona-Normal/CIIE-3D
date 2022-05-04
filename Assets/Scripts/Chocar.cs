using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocar : MonoBehaviour
{


    void Update()
    {
        Rigidbody rb = gameObject.GetComponent("Rigidbody") as Rigidbody;
        if (rb.IsSleeping()) {
            rb.WakeUp();
        }
    }
}
