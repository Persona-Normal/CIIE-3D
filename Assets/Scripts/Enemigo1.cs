using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public LayerMask ground;
    public float speed;

    public GameObject target;
    public bool atacando;
    public RangoEnemigo rango;
    public IaSensor vision;

    // Start is called before the first frame update
    void Start()
    {
        vision = GetComponent<IaSensor>();
        ani = GetComponent<Animator>();
        target = GameObject.Find("PlayerArmature");
    }


    public void Comportamiento_Enemigo()
    {
        Vector3 pos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 pos2 = new Vector3(transform.position.x, transform.position.y-5, transform.position.z);

        if (Physics.Linecast(pos1, pos2, ground)){
            Debug.Log("aaah prro, asi si");
        }

        
        if (Vector3.Distance(transform.position, target.transform.position) > 5 && !vision.IsInSight(target))
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            if (((Vector3.Distance(transform.position, target.transform.position) > 1 )|| (vision.IsInSight(target))) && !atacando)
            {
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("run", false);
                ani.SetBool("walk", false);
                
            }
        }
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<CapsuleCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }
}
