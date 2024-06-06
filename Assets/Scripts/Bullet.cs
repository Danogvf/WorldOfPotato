using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 150f;
    Rigidbody rb;
    float Destroytime = 3;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
   
    // Update is called once per frame
    void Update()
    {
        Destroytime -= Time.deltaTime;
        if (Destroytime >= 0)
        {
            Destroy(gameObject, Destroytime);
        }
        
    }
}
