using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Player player;
    [SerializeField] private int initialHealth = 1;
    [SerializeField] private float speed = 0.9f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        player = player ?? FindObjectOfType<Player>();
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;

        Health = initialHealth;
    }

    private void Update()
    {
        if (player)
        {
            // Calcula la dirección hacia el jugador
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Utiliza LookAt para que el enemigo mire hacia la dirección del jugador
            transform.LookAt(transform.position);

            // Mueve al enemigo en la dirección hacia el jugador
            transform.position += directionToPlayer.normalized * Time.deltaTime * speed;

        }
    }

    void LateUpdate()
    {
        // Voltea el sprite según la dirección de movimiento
        if (transform.position.x < player.transform.position.x)
        {
            _spriteRenderer.flipX = true; // Volteo horizontal
        }
        else
        {
            _spriteRenderer.flipX = false; // Sin volteo
        }
    }

    public int Health { get; private set; }

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        // Realizar acciones antes de la destrucción (por ejemplo, reproducción de animación).
        gameObject.SetActive(false);

        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player collidedPlayer = collision.GetComponent<Player>();
            if (collidedPlayer != null)
            {
                collidedPlayer.TakeDamage();
            }
        }
    }
}
