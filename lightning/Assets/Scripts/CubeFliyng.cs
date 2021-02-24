using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFliyng : MonoBehaviour
{
    

    public float minSpeed =0.01f;
    public float maxSpeed = 0.03f;
    private float speed;
    public Transform endZone;

    // Start is called before the first frame update
    void Start()
    {
        speed= Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
 
        transform.position -= transform.up * speed;
      
        if (transform.position.y < endZone.position.y-10f)
        {
            transform.DetachChildren();
            Object.Destroy(gameObject);            
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if(other.tag=="Player")
        {
  
            other.transform.SetParent(transform);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
