using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminar : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        ControlDedisparo script1 = Player.GetComponent<ControlDedisparo>();
        if (script1.disparo == false)
        {
            Destroy(gameObject);
        }
    }

}
