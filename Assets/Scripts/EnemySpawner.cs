using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;
    [SerializeField]
    private GameObject flyingSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;
    [SerializeField]
    private float flyingSwarmerInterval = 5f;

    [SerializeField]
    private float spawnRadius;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTransform != null)
        {
            StartCoroutine(SpawnEnemy(swarmerInterval, swarmerPrefab));
            StartCoroutine(SpawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
            StartCoroutine(SpawnEnemy(flyingSwarmerInterval, flyingSwarmerPrefab));
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Vector3 spawnPosition = playerTransform.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    public void IncreaseDifficulty()
    {
       Debug.Log("Increasing difficulty");

        swarmerInterval -= 0.4f;
        bigSwarmerInterval -= 0.5f;
        flyingSwarmerInterval -= 0.3f;

        if (swarmerInterval < 0.2f)
        {
            swarmerInterval = 0.2f;
        }
        if (bigSwarmerInterval < 0.2f)
        {
            bigSwarmerInterval = 0.2f;
        }
        if (flyingSwarmerInterval < 0.2f)
        {
            flyingSwarmerInterval = 0.2f;
        }
    }
}


