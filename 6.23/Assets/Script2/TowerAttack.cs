using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 3f;
    public float interval = 1f;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, interval);
    }

    void Shoot()
    {
        GameObject target = FindNearestEnemy();
        if (target == null) return;  

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetTarget(target);
    }


    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        GameObject nearest = null;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < minDist && dist <= range)
            {
                minDist = dist;
                nearest = e;
            }
        }
        return nearest;
    }
}
