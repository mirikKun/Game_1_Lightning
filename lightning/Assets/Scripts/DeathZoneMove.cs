using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneMove : MonoBehaviour
{
    public float speed = 0.05f;
    
    private float deathZoneComing;
    private float smoothComing=0.4f;
    public GameObject player;
    private float y;
    private Vector3 moving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.GetComponent<SimpleController>().isOnCheckPoint)
        {
            y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y-20, ref deathZoneComing, smoothComing);
            moving = new Vector3(transform.position.x, y, transform.position.z);
            transform.position = moving;

        }
        else
        {
            transform.position += transform.up * speed;
        }
    }
}
