using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_AxisMovement : MonoBehaviour
{
    public float distance; // Distancia de recorrido de la plataforma
    public float speed; // Velocidad de movimiento de la plataforma
    float movementCounter = 0; //Contador para saber cuando se ha cubierto la distancia de recorrido para invertir el signo de movimiento
    bool forward = true; // Indica si se está moviendo hacia adelante o hacia atrás.
    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        float movement = speed * Time.deltaTime;
        movementCounter += movement;

        if (forward)
        {
            //m_rigidbody.MovePosition(transform.position + Vector3.forward * movement);
            transform.Translate(Vector3.forward * movement, Space.World);

        }
        else {
            //m_rigidbody.MovePosition(transform.position + Vector3.back * movement);
            transform.Translate(Vector3.back * movement, Space.World);
        }

        if (movementCounter >= distance) 
        {
            movementCounter = 0;
            forward = !forward;
        }


    }

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.transform.SetParent(transform, true);
    }

    void OnTriggerExit(Collider col)
    {
        col.gameObject.transform.parent = null;
    }
}
