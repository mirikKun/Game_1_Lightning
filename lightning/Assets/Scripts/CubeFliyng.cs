using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFliyng : MonoBehaviour
{

   // GameManager gm = new GameManager();
    public float minSpeed =0.1f;
    public float maxSpeed = 0.3f;
    private float speed;
    public Transform endZone;
    public float distToAccel=85;
    public float acceleration = 1;
    public GameObject gm;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        speed= Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(transform.position.y-player.position.y>distToAccel)
        {
            acceleration = gm.GetComponent<GameManager>().cubeAcceleratioon;    
        }
        else
        {
            acceleration = 1;
        }
        transform.position -= transform.up * speed*acceleration;
        if (transform.position.y < endZone.position.y-10f)
        {
            transform.DetachChildren();
            Object.Destroy(gameObject);            
        }
            
    }


}
