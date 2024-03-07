using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerControler : MonoBehaviour
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
         if(Input.GetKeyDown(KeyCode.Space)){

            disparo=true;
           // proyectil.gameObject.SetActive(true);
            StartCoroutine(Eliminar());
        }
    }
   IEnumerator Eliminar(){
        Instantiate(proyectil, transform.position, proyectil.transform.rotation);
        yield return new WaitForSeconds(3);
        disparo=false;
        //proyectil.gameObject.SetActive(false);
    }
}
