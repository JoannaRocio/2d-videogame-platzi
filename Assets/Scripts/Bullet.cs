using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10;

    private void Start()
    {
        Destroy(gameObject, 1.2f);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
