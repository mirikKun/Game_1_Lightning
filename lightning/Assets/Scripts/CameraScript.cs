using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    public float limitY =50;
    public float height = 6;
    private float hideDist = 3.2f;
    public float maxDistance =10;

    private float currentDistance=10;
    private Vector3 offset;
    private Vector3 direction;



    public LayerMask obstacles;
    public LayerMask noPlayer;
    private LayerMask origin;
    

    private float turnSpeedY = 20;
    private float turnSpeedX = 30;
    private float invert = -1;

    float yrot;
    float xrot;
    // Start is called before the first frame update
    void Start()
    {
        origin = cam.cullingMask;
        transform.LookAt(target);
        invert = GameOptions.inverted;
        turnSpeedY = GameOptions.yVelocity;
        turnSpeedX = GameOptions.xVelocity;
}


    void LateUpdate()
    {
        CameraRotion();
        ObstaclesReact();
        PlayerReact();
    }
    void CameraRotion()
    {
        xrot += Input.GetAxis("Mouse X")* turnSpeedX * Time.deltaTime ;
        yrot += Input.GetAxis("Mouse Y")*turnSpeedY * Time.deltaTime;

        yrot = Mathf.Clamp(yrot, -limitY, limitY);
        direction = new Vector3(0, 0, currentDistance);
        Quaternion rot = Quaternion.Euler(invert * yrot,xrot ,0);
        transform.position = target.position + rot * direction;
        transform.LookAt(target.position);

    }


    void PlayerReact()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        if(currentDistance<hideDist)
        {
            cam.cullingMask = noPlayer;
        }
        else
        {
            cam.cullingMask = origin;
        }
    }

    void ObstaclesReact()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, maxDistance, obstacles)) 
        {
            transform.position = hit.point+transform.forward*0.5f;
            currentDistance = distance;
        }
        else if(distance<maxDistance && !Physics.Raycast(transform.position,-transform.forward,0.1f,obstacles))
        {
            transform.position -= transform.forward * 0.05f;
        }
        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
    }

}
