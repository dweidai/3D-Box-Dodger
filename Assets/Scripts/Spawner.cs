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
    public int prepareDis = 200;

    int objectSelect;
    float lowerBound = 0.2f;
    float EPSILON = 0.001f;
   public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 600)
        {
            if (System.Math.Abs(spawnLeastWait - lowerBound) > EPSILON)
            {
                spawnLeastWait = spawnLeastWait - 0.05f;
            }
            else
            {
                if(System.Math.Abs(spawnLeastWait - spawnMostWait) > lowerBound)
                spawnMostWait = spawnMostWait - 0.05f;
            }
            count = 0;
        }
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        count++;
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (stop == false)
        {
            objectSelect = Random.Range(0, 2);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.2f, player.position.z + Random.Range(prepareDis, spawnValues.z*100));
            Instantiate(obstacles[objectSelect], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
