using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDammage : MonoBehaviour
{
    // Start is called before the first frame update
    public float radio =5;
    bool jugadorDanado = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] objetosTocados = Physics.OverlapSphere(transform.position, radio);

        foreach (Collider item in objetosTocados)
        {
            if(!jugadorDanado && item.TryGetComponent(out LifePlayer lifePlayer)){
                lifePlayer.TomarDano();
                jugadorDanado =true;
            }
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
