using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDedisparo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proyectil;
    public bool disparo=false;
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
        Instantiate(proyectil, transform.position,transform.rotation);
        yield return new WaitForSeconds(2);
        disparo=false;
       
    }
}
