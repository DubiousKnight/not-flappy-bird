using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacleObj;

    public Vector2 spawnRange;
    public float spawnRate;

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        this.spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.spawnTimer += Time.deltaTime;

        if (this.spawnTimer > this.spawnRate) {
            SpawnObstacle();
        }
    }

    void SpawnObstacle() {

        float yPos = Random.Range(this.spawnRange.x, this.spawnRange.y);

        Vector3 currentPos = this.transform.position;
        Vector3 spawnPos = new Vector3(currentPos.x, yPos, currentPos.z);

        GameObject newObs = Instantiate(this.obstacleObj, spawnPos, Quaternion.identity);
        newObs.transform.SetParent(this.transform);
        this.spawnTimer = 0;
    }
}
