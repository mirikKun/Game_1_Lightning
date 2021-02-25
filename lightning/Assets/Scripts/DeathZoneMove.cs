using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneMove : MonoBehaviour
{
    public float speed = 0.05f;

    public float ditanceToPlayer = 75f;
    public float checkPoint = 40f;
    private float y;
    public GameObject player;
    
    private Vector3 moving;
    private float deathZoneComing;
    private float smoothComing=1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.GetComponent<SimpleController>().isOnCheckPoint)
        {
            y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y- checkPoint, ref deathZoneComing, smoothComing);
            moving = new Vector3(transform.position.x, y, transform.position.z);
            transform.position = moving;

        }
        else
        {
            if (player.transform.position.y- transform.position.y> ditanceToPlayer)
            {
                y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y - ditanceToPlayer, ref deathZoneComing, smoothComing);
                moving = new Vector3(transform.position.x, y, transform.position.z);
                transform.position = moving;
            }
            transform.position += transform.up * speed;
            
        }
    }
}
