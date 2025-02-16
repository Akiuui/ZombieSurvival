using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Vector2 xBounds = new Vector2(-120, 120);
    public Vector2 zBounds = new Vector2(-57, 180);
    public Transform zombieContainer;
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
            float random = Random.Range(0f, 360f);
            Quaternion randomRotation = Quaternion.Euler(0f, random, 0f);

            int randIndex = Random.Range(0, 2);

            GameObject enemy = Instantiate(enemyPrefab[randIndex], hit.position, randomRotation);
            enemy.transform.SetParent(zombieContainer);
        }
        else
        {
            print("No valid NavMesh position found near " + randomPosition);
        }
    }
}
