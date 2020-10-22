using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject playerFoe; // reference to the enemy 

    public float spawnRate; // the rate at which the enemy spawns
    public float distanceFromCenter = 5f; // used to control how far the enemy spawns from the player
    float spawnTime; // how long it takes for enemies to spawn

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time + spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        // creates a circle that the enemies will spawn on
        Vector2 randomPosOnCircle = Random.insideUnitCircle.normalized * distanceFromCenter;

        if (Time.time > spawnTime)
        {
            // instantiates an enemy at a random point on the circle and resets the timer
            GameObject newPrefab = Instantiate(playerFoe);
            newPrefab.transform.position = new Vector3(randomPosOnCircle.x, 0, randomPosOnCircle.y);
            spawnTime = Time.time + spawnRate;
        }
    }
}
