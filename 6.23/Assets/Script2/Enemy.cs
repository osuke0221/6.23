using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    int waypointIndex = 0;

    public int hp = 3;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypointIndex < waypoints.Length)
        {
            Transform target = waypoints[waypointIndex];
            Vector3 dir = (target.position - transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
