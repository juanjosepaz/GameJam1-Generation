using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MovEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=5;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    public AudioClip impact;
    
    
    void Start()
    {
         
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
         transform.LookAt(playerGoal.transform);
         transform.position = Vector3.MoveTowards(transform.position, playerGoal.transform.position, speed*Time.deltaTime);
         
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Proyectil")
        {
            GameObject ene = GameObject.Find("contados");
            cont contene = ene.GetComponent<cont>();
            contene.Enemigo();
            Destroy(gameObject);
            Destroy (other.gameObject);

            SoundManager.Instance.PlaySoundFx(impact);

        }
        

    }
 }

