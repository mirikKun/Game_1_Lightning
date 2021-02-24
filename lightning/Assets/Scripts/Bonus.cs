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

    void Start()
    { 
   
    }

    void Update()
    {
        
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
