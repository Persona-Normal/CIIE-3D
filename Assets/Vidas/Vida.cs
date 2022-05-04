using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public static int vidas= 3;
    public int vidaPublica; 
    //para que no se haga mucho daño de un solo golpe        
    public bool canDamage = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaPublica = vidas;
        Debug.Log("update");
    }


    // Para los enemigos debería ser Collide, no Trigger
    public void OnTriggerEnter(Collider col){

        Debug.Log("ala");
        if(!canDamage){
            return;
        }
        if(col.CompareTag("Enemy") || col.CompareTag("EnvironmentalHazard"))
        {
            //no nos puede hacer daño hasta dentro de 1 seg
            canDamage = false;
            Invoke("ActivarDano",1);            
            
            Debug.Log("hit");

            if(MAnzanas.manzanas != null){
                MAnzanas.manzanas.reducirManzana();
                vidas -= 1;
            }        

            if(vidas <=0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void ActivarDano(){
        canDamage = true;
    }

    
}
