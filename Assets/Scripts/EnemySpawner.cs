using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject player;


    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float bigSwarmerInterval;
    [SerializeField]
    private float swarmerInterval;

    [SerializeField] float spawnaRadius;

    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition;
        bool isVisible;

        do
        {
            spawnPosition = player.transform.position + player.transform.position + new Vector3(Random.Range(-spawnaRadius, spawnaRadius), Random.Range(-spawnaRadius, spawnaRadius), 0);

            isVisible = IsPositionOutSideCameraView(spawnPosition);
        }
        while (!isVisible);

        return spawnPosition;
        
        }

    private bool IsPositionOutSideCameraView(Vector3 position)
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

        return viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(enemy, spawnPosition, Quaternion.identity);

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
