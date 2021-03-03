using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            other.transform.SetParent(transform.parent);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
    private void Update()
    {
        if(transform.parent==null)
        {
            Object.Destroy(gameObject);
        }
    }
}
