using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform player;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int objectSelect;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (stop == false)
        {
            objectSelect = Random.Range(0, 2);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.2f, player.position.z + Random.Range(100, spawnValues.z*100));
            Instantiate(obstacles[objectSelect], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
