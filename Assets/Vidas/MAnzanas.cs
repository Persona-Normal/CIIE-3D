using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAnzanas : MonoBehaviour
{   
    public GameObject[] Manzanas;
    public Queue<GameObject> manzanasCola = new Queue<GameObject>();
    public static MAnzanas manzanas;

    // Para inicializar
    void Start()
    {
        manzanas = this;
        foreach(GameObject g in Manzanas )
        {
            manzanasCola.Enqueue(g);
            g.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
    }

    //para reducir las manzanas por orden 
    public void reducirManzana(){
        GameObject g = manzanasCola.Dequeue();
        g.gameObject.SetActive(false);
        manzanasCola.Enqueue(g);
    }
}
