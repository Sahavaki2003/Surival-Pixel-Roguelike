
using System.Collections;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float bulletSpeed = 10f;

    private Coroutine shootingCoroutine;
    private void Start()
    {
        shootingCoroutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            SpawnBullet();

            yield return new WaitForSeconds(fireRate);
        }
    }

    private void SpawnBullet()
    {
        if (bulletPrefab == null || firePoint == null)
            return;

        GameObject bullet = Instantiate(bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}
