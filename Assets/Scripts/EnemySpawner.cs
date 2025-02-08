using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 xBounds = new Vector2(-120, 120);
    public Vector2 zBounds = new Vector2(-57, 180);

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(xBounds.x, xBounds.y),
            0,
            Random.Range(zBounds.x, zBounds.y)
        );

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, 10.0f, NavMesh.AllAreas))
        {
            Instantiate(enemyPrefab, hit.position, Quaternion.identity);
        }
        else
        {
            print("No valid NavMesh position found near " + randomPosition);
        }
    }
}
