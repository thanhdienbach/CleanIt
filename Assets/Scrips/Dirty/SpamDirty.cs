using System.Collections;
using UnityEngine;

public class SpamDirty : MonoBehaviour
{
    public GameObject dirty;
    public GameObject key;
    public float minSpawnTime = 8;
    public float maxSpawnTime = 16;
    public float randomX;
    public float randomZ;

    public int count;

    void Start()
    {
        count = 0;
        StartCoroutine(SpamDir());
    }

    // Update is called once per frame
    void Update()
    {
        //if (count == 4)
        //{
        //    SpamKey();
        //    count = 0;
        //}
    }

    private IEnumerator SpamDir()
    {
        while (count < 4)
        {
            float ramdomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(ramdomTime);
            randomX = transform.position.x + Random.Range(-0.5f, 0.5f);
            randomZ = transform.position.z + Random.Range(-0.5f, 0.5f);
            Vector3 randomPosition = new Vector3(randomX, 0.2f, randomZ);
            Instantiate(dirty, randomPosition, Quaternion.identity);
            count += 1;
        }
        while (count > 3)
        {
            float ramdomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(ramdomTime);
            randomX = transform.position.x + Random.Range(-0.5f, 0.5f);
            randomZ = transform.position.z + Random.Range(-0.5f, 0.5f);
            Vector3 randomPosition = new Vector3(randomX, 0.2f, randomZ);
            Instantiate(key, randomPosition, Quaternion.identity);
            count = 0;
        }
    }
    private IEnumerator SpamKey()
    {
        while (true)
        {
            float ramdomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(ramdomTime);
            randomX = transform.position.x + Random.Range(-0.5f, 0.5f);
            randomZ = transform.position.z + Random.Range(-0.5f, 0.5f);
            Vector3 randomPosition = new Vector3(randomX, 0.2f, randomZ);
            Instantiate(key, randomPosition, Quaternion.identity);
        }
    }

}
