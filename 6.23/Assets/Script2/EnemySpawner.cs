using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public Transform[] waypoints;   //  Ç±Ç±Ç…ìπÇê›íËÇ∑ÇÈ

    public float minDelay = 1f;
    public float maxDelay = 3f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            //  ê∂ê¨ÇµÇΩìGÇ… waypoint ÇìnÇ∑
            Enemy e = enemy.GetComponent<Enemy>();
            e.waypoints = waypoints;
        }
    }
}
