using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEvents : MonoBehaviour
{
    public GameObject groundTilePrefab;
    Vector3 nextSpawnPoint;

    public void spawnTile()
    {
        GameObject groundTemp = Instantiate(groundTilePrefab, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = groundTemp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnTile();
        }
    }

    // Update is called once per frame
    //void Update()
    //{ 

    //}
}
