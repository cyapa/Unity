using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnTime;  
    public Transform[] spawnPoints;
    public GameObject[] spawnObj;  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnObj", spawnTime, spawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObj ()
    {
        //Get random Spawn location
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        //Get random Spawn object
        int spawnObjIndex = Random.Range (0, spawnObj.Length);

        //Spawn random pickup obj in random location
        Instantiate (spawnObj[spawnObjIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
