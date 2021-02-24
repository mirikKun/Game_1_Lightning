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
    private int boost;

    void Start()
    { 
        if (bonus == Bonuses.doubleJump)
        {
            print("doubleJump");
            boost = 1;
        }
        else if(bonus == Bonuses.wallJump)
        {
            print("wallJump");
            boost = 2;
        }
        else if (bonus == Bonuses.rush)
        {
            print("rush");
            boost = 3;
        }
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            

        }
    }
}
