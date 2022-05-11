using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    int vidas= 3;
    //para que no se haga mucho daño de un solo golpe        
    bool canDamage = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnTriggerEnter(Collider col) {

        if (col.CompareTag("HazardousTerrain"))
        {
            vidas = 0;
        }

    }
    
    public void OnTriggerStay(Collider col){

        if(!canDamage){
            return;
        }

        if(col.CompareTag("EnvironmentalHazard"))
        {
            //no nos puede hacer daño hasta dentro de 1 seg
            canDamage = false;
            Invoke("ActivarDano",1);            
            
            Debug.Log("hit");

            if(MAnzanas.manzanas != null){
                MAnzanas.manzanas.reducirManzana();
                vidas -= 1;
            }        

            
        }
        
    }

    void ActivarDano(){
        canDamage = true;
    }

    
}
