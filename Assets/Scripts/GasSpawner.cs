using UnityEngine;

public class GasSpawner : MonoBehaviour
{
    public GameObject gasPrefab; // 가스 아이템 프리팹
    public float spawnInterval = 4f; // 가스 생성 간격
    public float spawnYPosition = 6f; // 가스 생성 Y 위치
    public float[] spawnXPositions = { -2f, 0f, 2f }; // X축 스폰 위치 배열

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGas();
            timer = 0f;
        }
    }

    void SpawnGas()
    {
        // X축에서 무작위 위치 선택
        float randomX = spawnXPositions[Random.Range(0, spawnXPositions.Length)];
        Vector2 spawnPosition = new Vector2(randomX, spawnYPosition);

        // 가스 생성
        Instantiate(gasPrefab, spawnPosition, Quaternion.identity);
    }
}