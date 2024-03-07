using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDedisparo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proyectil;
    public bool disparo=false;
    //public float altura= 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0)){
            disparo=true;
            StartCoroutine(Eliminar());
        }
    }
   IEnumerator Eliminar(){
      Vector3 posicionProyectil = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        Instantiate(proyectil, posicionProyectil,transform.rotation);
        yield return new WaitForSeconds(2);
        disparo=false;
       
    }
}
