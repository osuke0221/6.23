using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private GameObject target;

    public void SetTarget(GameObject t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (target.transform.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            target.GetComponent<Enemy>().Damage(1);
            Destroy(gameObject);
        }
    }
}
