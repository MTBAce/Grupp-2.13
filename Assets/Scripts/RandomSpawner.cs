using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefaben som ska spawnas
    public Vector2 spawnAreaMin; // Minsta x- och y-koordinater
    public Vector2 spawnAreaMax; // St�rsta x- och y-koordinater
    public int spawnCount = 10; // Antal prefabs att spawna per minut
    public float spawnInterval = 60f; // Tid mellan varje spawn (sekunder)

    void Start()
    {
        // Starta Coroutine f�r att spawna prefabs regelbundet
        StartCoroutine(SpawnPrefabsEveryMinute());
    }

    IEnumerator SpawnPrefabsEveryMinute()
    {
        while (true)
        {
            SpawnPrefabs();
            yield return new WaitForSeconds(spawnInterval); // V�nta innan n�sta spawn
        }
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Generera en slumpm�ssig position inom omr�det
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);

            // Spawna prefaben vid den slumpm�ssiga positionen
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        // Visualisera spawn-omr�det i scenen
        Gizmos.color = Color.green;
        Vector2 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawWireCube((Vector2)spawnAreaMin + size / 2, size);
    }
}
