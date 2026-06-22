using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 1.5f;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, interval);
    }

    void Spawn()
    {
        float x = Random.Range(-4f, 4f);
        Vector3 pos = new Vector3(x, 6f, 0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
