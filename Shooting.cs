using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private float _interval;

    private void Start()
    {
        var shoot = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 direction = (_gunBarrel.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.transform.up = direction;
            rigidbody.velocity = direction * _force;

            yield return new WaitForSeconds(_interval);
        }
    }
}
