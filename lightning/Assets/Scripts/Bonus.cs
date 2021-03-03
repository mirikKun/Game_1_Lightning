using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [System.Serializable]
    public enum Bonuses
    {
        doubleJump,
        wallJump,
        rush
    }
    public Bonuses bonus;
    private Vector3  startPosition;
    public Vector3 randoMome=Vector3.up;
    public float step=10;
    private float direction=1;

    private Vector3 smoothmove;

    void Start()
    {

        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = transform.position + randoMome* direction;
        if (transform.position.y-startPosition.y> step) 
        {
            direction =  -1;         
        }
        else if(transform.position.y - startPosition.y < -step)
        {
            direction = 1;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (bonus == Bonuses.doubleJump)
            {
                other.GetComponent<SimpleController>().doubleJumpAvailable = true;
            }
            else if (bonus == Bonuses.wallJump)
            {
                other.GetComponent<SimpleController>().wallJumpAvailable = true;
            }
            else if (bonus == Bonuses.rush)
            {
                other.GetComponent<SimpleController>().rushAvailable = true;
            }
            Object.Destroy(transform.parent.gameObject);

        }
    }
}
