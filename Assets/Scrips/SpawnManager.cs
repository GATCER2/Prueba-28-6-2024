using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    private float destroyYPoint = 1.0f;

    private Moviemiento player;

    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);

        player = GameObject.Find("Player").GetComponent<Moviemiento>();
    }

    void SpawnObjects()
    {
        Vector3 spawnOffset = Random.insideUnitCircle;
        Vector3 spawnPosition = new Vector3(spawnOffset.x, 12 + spawnOffset.y, 5 + spawnOffset.z);

        int index = Random.Range(0, objectPrefabs.Length);
        GameObject objectToSpawn = objectPrefabs[index];

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            StartCoroutine(DestroyAfterYPoint(rb));
        }
    }

    IEnumerator DestroyAfterYPoint(Rigidbody rb)
    {
        while (rb.position.y > destroyYPoint)
        {
            yield return null;
        }
        Destroy(rb.gameObject);
    }
}
