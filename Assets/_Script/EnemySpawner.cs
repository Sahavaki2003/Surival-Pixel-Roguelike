
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Camera mainCamera;

    [Header("Wave Settings")]
    [SerializeField] private int enemiesPerWave = 2;
    [SerializeField] private int increasePerWave = 2;
    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float spawnDelay = 0.3f;

    [Header("Spawn Outside Camera")]
    [SerializeField] private float spawnOffset = 2f;

    private int currentWave = 0;
    private int aliveEnemies = 0;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;

            Debug.Log($"Wave {currentWave}: Spawn {enemiesPerWave} enemies");

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();

                yield return new WaitForSeconds(spawnDelay);
            }

            // Chờ đến khi toàn bộ quái bị tiêu diệt
            yield return new WaitUntil(() => aliveEnemies == 0);

            Debug.Log($"Wave {currentWave} completed!");

            // Nghỉ trước khi bắt đầu đợt tiếp theo
            yield return new WaitForSeconds(timeBetweenWaves);

            enemiesPerWave += increasePerWave;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null || mainCamera == null)
        {
            Debug.LogWarning("EnemySpawner: Chưa gán đủ references!");
            return;
        }

        Vector3 spawnPosition = GetSpawnPositionOutsideCamera();

        GameObject enemy = Instantiate(enemyPrefab,spawnPosition,Quaternion.identity);

        // Gắn thông tin Spawner vào Enemy vừa tạo
        EnemyWaveMember waveMember = enemy.AddComponent<EnemyWaveMember>();
        waveMember.SetSpawner(this);

        aliveEnemies++;
    }

    public void OnEnemyDied()
    {
        aliveEnemies--;

        Debug.Log($"Enemies remaining: {aliveEnemies}");
    }

    private Vector3 GetSpawnPositionOutsideCamera()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        int side = Random.Range(0, 4);

        float x = 0f;
        float y = 0f;

        switch (side)
        {
            case 0:
                x = -cameraWidth - spawnOffset;
                y = Random.Range(-cameraHeight, cameraHeight);
                break;

            case 1:
                x = cameraWidth + spawnOffset;
                y = Random.Range(-cameraHeight, cameraHeight);
                break;

            case 2:
                x = Random.Range(-cameraWidth, cameraWidth);
                y = -cameraHeight - spawnOffset;
                break;

            case 3:
                x = Random.Range(-cameraWidth, cameraWidth);
                y = cameraHeight + spawnOffset;
                break;
        }

        return new Vector3(
            mainCamera.transform.position.x + x,
            mainCamera.transform.position.y + y,
            0f
        );
    }
}

public class EnemyWaveMember : MonoBehaviour
{
    private EnemySpawner spawner;
    private bool hasReportedDeath = false;

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        spawner = enemySpawner;
    }

    public void ReportDeath()
    {
        if (hasReportedDeath)
            return;

        hasReportedDeath = true;

        if (spawner != null)
            spawner.OnEnemyDied();
    }
}
