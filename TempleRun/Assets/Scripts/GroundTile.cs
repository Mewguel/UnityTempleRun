using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    private GroundEvents groundSpawner;

    public GameObject[] obstaclePrefabs;
    public Transform[] spawnpoints;


    private void Awake()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundEvents>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacles();
    }

    private void onTriggerExit(Collider other)
    {
        groundSpawner.spawnTile();

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacles()
    {
        int spawnPointIndex = Random.Range(0, spawnpoints.Length);
        int spawnPrefab = Random.Range(0, obstaclePrefabs.Length);

        Instantiate(obstaclePrefabs[spawnPrefab], spawnpoints[spawnPointIndex].transform.position, Quaternion.identity, transform);
    }
}
