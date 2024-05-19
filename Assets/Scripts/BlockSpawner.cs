using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;  // Farklı renklerdeki blok prefablarını tutan dizi
    public float spawnInterval = 1.0f; // Blokların ne sıklıkla üretileceği
    public Vector2 spawnAreaMin;       // Spawn alanının sol alt köşesi
    public Vector2 spawnAreaMax;       // Spawn alanının sağ üst köşesi
    public float gridSize = 1.0f;      // Grid hücre boyutu

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnBlock();
            timer = spawnInterval;
        }
    }

    void SpawnBlock()
    {
        // Rastgele bir pozisyon seçme
        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = spawnAreaMax.y;

        // Pozisyonu grid boyutuna yuvarlama
        spawnX = Mathf.Round(spawnX / gridSize) * gridSize;
        spawnY = Mathf.Round(spawnY / gridSize) * gridSize;

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Rastgele bir blok prefabı seçme
        int randomIndex = Random.Range(0, blockPrefabs.Length);
        GameObject blockPrefab = blockPrefabs[randomIndex];

        // Bloku üretme
        Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }
}