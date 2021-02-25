using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float minSecondsBetweenSpawning = 5.0f;
    public float maxSecondsBetweenSpawning = 10.0f;
    public GameObject cube;
    public   int  spawnGridSize = 4;
    int[,] smawnGrid ;
    private int cubeNumber = 0;
    public Transform endZone;
    private float savedTime;
    private float secondsBetweenSpawning;
    public  GameObject gm;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        smawnGrid = new int[spawnGridSize + 1, spawnGridSize + 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            CubesSpawn();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }
        if(cubeNumber == spawnGridSize*spawnGridSize)
        {
            for (int i = 0; i < spawnGridSize ; i++)
            {
                for (int j = 0; j < spawnGridSize; j++)
                {
                    smawnGrid[i, j] = 0;
                }
            }
            cubeNumber = 0;
        }
    }

    void CubesSpawn()
    {
        int snapX = (int)Random.Range(0, spawnGridSize);
        int snapZ = (int)Random.Range(0, spawnGridSize );
        
            while (smawnGrid[snapX , snapZ ] == 1)
            {
                 snapX = (int)Random.Range(0, spawnGridSize );
                 snapZ = (int)Random.Range(0, spawnGridSize );

            }
            smawnGrid[snapX, snapZ] = 1;
        cubeNumber++;
        GameObject clone = Instantiate(cube, transform.position+Vector3.right* snapX * 10+Vector3.forward* snapZ * 10, transform.rotation) as GameObject;
        clone.transform.parent = transform;
        CubeFliyng newCubeScript = clone.GetComponent<CubeFliyng>();
        newCubeScript.endZone = endZone;
        newCubeScript.gm = gm;
        newCubeScript.player = player;
    }
}
