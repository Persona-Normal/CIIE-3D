using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionesManejador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked() {
        SceneManager.LoadScene("acid");
        // Podría ser SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); si confiamos en el orden de escenas
    }
}
