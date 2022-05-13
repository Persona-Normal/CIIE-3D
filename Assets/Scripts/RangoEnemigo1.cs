using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo1 : MonoBehaviour
{
    public Animator ani;
    public Enemigo2 enemigo;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            ani.SetBool("run", false);
            ani.SetBool("walk", false);
            ani.SetBool("attack", true);
            enemigo.atacando = true;
            GetComponent<CapsuleCollider>().enabled=false;
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
