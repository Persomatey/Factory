using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWave : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject enemy;
    public float spawnCooldown;
    public bool multipleWave;
    public int NumWaves;

    private float nextSpawnTime;
    private int waves;

    // Use this for initialization
    void Start()
    {
        nextSpawnTime = 0f;
        waves = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (enemy == null)
            return;
        if (Time.time < nextSpawnTime)
            return;
        if (!other.tag.Contains("Player"))
            return;
        Debug.Log("Spawner Triggered");
        foreach (GameObject spawner in spawners)
        {
            Instantiate(enemy, spawner.transform.position, spawner.transform.rotation);
            nextSpawnTime = Time.time + spawnCooldown;
            waves++;
        }
        //Destroy(gameObject);

        if (!multipleWave)
        {
            Destroy(gameObject);
        }

        if (waves > NumWaves)
        {
            Destroy(gameObject);
        }
    }
}