using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefaben som ska spawnas
    public Vector2 spawnAreaMin; // Minsta x- och y-koordinater
    public Vector2 spawnAreaMax; // Största x- och y-koordinater
    public int spawnCount = 10; // Antal prefabs att spawna per minut
    public float spawnInterval = 60f; // Tid mellan varje spawn (sekunder)

    void Start()
    {
        // Starta Coroutine för att spawna prefabs regelbundet
        StartCoroutine(SpawnPrefabsEveryMinute());
    }

    IEnumerator SpawnPrefabsEveryMinute()
    {
        while (true)
        {
            SpawnPrefabs();
            yield return new WaitForSeconds(spawnInterval); // Vänta innan nästa spawn
        }
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Generera en slumpmässig position inom området
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);

            // Spawna prefaben vid den slumpmässiga positionen
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        // Visualisera spawn-området i scenen
        Gizmos.color = Color.green;
        Vector2 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawWireCube((Vector2)spawnAreaMin + size / 2, size);
    }
}
