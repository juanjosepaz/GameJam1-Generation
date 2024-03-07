using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlDedisparo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject proyectil;
    public bool disparo = false;
    //public float altura= 1.0f;

    [Header("Shoot control")]
    [SerializeField] private int maxBulletAmount;
    public int actualBulletAmount;
    public UnityEvent OnPlayerShoot;
    public UnityEvent OnPlayerRecharge;

    private void Awake()
    {
        actualBulletAmount = maxBulletAmount;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (actualBulletAmount > 0)
        {
            Vector3 posicionProyectil = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            Instantiate(proyectil, posicionProyectil, transform.rotation);
            actualBulletAmount -= 1;
            OnPlayerShoot.Invoke();
        }
    }

    public void Recharge()
    {
        if (actualBulletAmount < maxBulletAmount)
        {
            actualBulletAmount += 1;
            OnPlayerRecharge.Invoke();
        }
    }
}
