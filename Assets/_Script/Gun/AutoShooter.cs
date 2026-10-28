
using System.Collections;
using UnityEngine;

public abstract class AbsAutoShooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;

    protected float fireRate;
    protected float bulletSpeed;

    private Coroutine shootingCoroutine;

    protected virtual void OnEnable()
    {
        shootingCoroutine = StartCoroutine(ShootRoutine());
    }

    private void OnDisable()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(fireRate);
        }
    }

    protected virtual GameObject SpawnBullet()
    {
        if (bulletPrefab == null || firePoint == null)
            return null;

        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        return bullet;
    }
}
