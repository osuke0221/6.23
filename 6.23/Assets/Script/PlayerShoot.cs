using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
        }
    }
}
