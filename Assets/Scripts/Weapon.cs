using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _shootingInterval = 1f;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        var wait = new WaitForSeconds(_shootingInterval);

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            SpawnBullet(direction);

            yield return wait;
        }
    }

    private void SpawnBullet(Vector3 direction)
    {
        Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

        newBullet.transform.up = direction;
        newBullet.velocity = direction * _bulletSpeed;
    }
}
