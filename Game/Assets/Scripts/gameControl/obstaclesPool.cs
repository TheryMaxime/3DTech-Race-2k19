using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesPool : MonoBehaviour
{
    public int obstaclesPoolSize = 10;
    private GameObject[] obstacles;
    public GameObject obstaclePrefab;
    private Vector3 objectPoolPosition = new Vector3(3.5f, 0.52f, 15f);
    private float timeSinceLastSpawn;
    public float spawnRate = 0.2f;
    public float obstacleMin = -3f;
    public float obstacleMax = 3f;
    private float spawnYPosition = 0.5f;
    private int currentObstacle = 0;

    float spawnZPosition;

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        
        obstacles = new GameObject[obstaclesPoolSize];
        for (int i = 0; i < obstaclesPoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }

        spawnZPosition = obstacles[currentObstacle].transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (gameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnXPosition = Random.Range(obstacleMin, obstacleMax);
            
            spawnZPosition += 20f;
            obstacles[currentObstacle].transform.position = new Vector3(spawnXPosition, spawnYPosition, spawnZPosition);
            currentObstacle++;
            if (currentObstacle >= obstaclesPoolSize)
            {
                currentObstacle = 0;
            }
        }
    }
}
