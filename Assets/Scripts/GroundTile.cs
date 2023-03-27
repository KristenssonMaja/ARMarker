using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    //[SerializeField] GameObject coinPrefab;

    static int obstableCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2); //destroy gameobject 2 seconds after the player leaves the trigger
    }
    

    public void SpawnObstacle ()
    {
        //Choose a random point to spawn the obstacle

        if (obstableCount % 5 == 0)
        {
            int obstacleSpawnIndex = 3;
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        
            // Spawn the obstacle at the position
            // Instantiate is Unitys fancy way of saying spawn :)
      
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
        obstableCount++;
        
       

    }

    

    /*public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for(int i=0; i < coinsToSpawn; i++ )
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
        Random.Range(collider.bounds.min.x, collider.bounds.max.x),
        Random.Range(collider.bounds.min.y, collider.bounds.max.y),
        Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1; //hight of the spawned coins
        return point;
    }*/
}
