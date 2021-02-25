using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform deathZone;
    public Transform startPoint;
    public GameObject gr;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position.y<deathZone.position.y)
        {
            gr.GetComponent<GameManager>().RestartGame();
                
        }

    }
}
