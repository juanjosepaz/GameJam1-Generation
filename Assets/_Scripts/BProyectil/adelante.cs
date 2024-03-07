using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adelante : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float lifeTime;
    public float speed = 40.0f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
