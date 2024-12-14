using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] items;
    [SerializeField] private float[] spawnRates;

    public float minTimeToSpawn = 4;
    public float maxTimeToSpawn = 8;

    public CharacterController characterController;
    public Vector3 randomDirection;
    public float timeToChangeDirection = 1f;
    public Vector3 originTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originTransform = transform.position;
        StartCoroutine(RandomDirection());
        StartCoroutine(SpawnRandomItem());
    }

    
    void Update()
    {
        RandomPosition();
    }
    void RandomPosition()
    {
        characterController.Move(randomDirection * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, originTransform.y, transform.position.z);
    }
    IEnumerator RandomDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToChangeDirection);
            randomDirection = transform.right * Random.Range(-1,2) + transform.forward * Random.Range(-1,2);
        }
    }
    
    IEnumerator SpawnRandomItem()
    {
        while (true)
        {
            float randomTimeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            yield return new WaitForSeconds(randomTimeToSpawn);
            Instantiate(RandomItem(), transform.position, Quaternion.identity);
        }
    }
    private GameObject RandomItem()
    {
        // Caculative total of spawnRates
        float totalRate = 0;
        foreach (var spawnRate in spawnRates)
        {
            totalRate += spawnRate;
        }

        // Random number
        float randomNumber = Random.Range(0, totalRate);

        // Choose item to spawn
        float cumulativeSpawnRate = totalRate;
        for (int i = 0; i < spawnRates.Length; i++)
        {
            cumulativeSpawnRate -= spawnRates[i];
            if (cumulativeSpawnRate < randomNumber)
            {
                return items[i];
            }
        }
        return null;
    }
}
