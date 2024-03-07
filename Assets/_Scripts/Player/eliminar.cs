using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminar : MonoBehaviour
{
    // Start is called before the first frame update
    private float lims=30;
  private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        PalyerControler script1 = Player.GetComponent<PalyerControler>();
         if (script1.disparo == false){
            Destroy(gameObject);
        }
    }
    
}
