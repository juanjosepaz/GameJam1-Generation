using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=5;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    
    void Start()
    {
        
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 lookDirection = transform.LookAt(playerGoal.transform);
        //enemyRb.AddForce( lookDirection* speed );
         transform.LookAt(playerGoal.transform);
         transform.position = Vector3.MoveTowards(transform.position, playerGoal.transform.position, speed*Time.deltaTime);
         
    }
 }

