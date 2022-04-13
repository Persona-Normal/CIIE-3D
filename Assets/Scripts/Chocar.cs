using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocar : MonoBehaviour
{


    void OnCollisionEnter(Collision col)
    {                
        if(col.gameObject.tag == "Player" ){
            Debug.Log("dale");
            Destroy(gameObject,.5f);
            }
    }
}
