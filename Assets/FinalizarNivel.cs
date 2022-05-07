using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Provisional -> Podr�a haber una pantalla con mensaje de 'nivel completado' antes de transicionar
    private void OnTriggerEnter(Collider col)
    {
        int nextScene;

        if (col.CompareTag("Player")) { 
           nextScene = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextScene < SceneManager.sceneCountInBuildSettings)
            { // A�n quedan niveles, transicionar al siguiente
                SceneManager.LoadScene(nextScene);
            }
            else { 
              // Est�bamos en el �ltimo nivel, terminar el juego (pensar como)
            }
        }
        
    }
}
