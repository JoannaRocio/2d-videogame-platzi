using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float velocidadMovimiento = 5f;
    private int direccion = 1;

    public Sprite[] sprites;  // Array de sprites a mostrar
    public float tiempoPorFrame = 1.0f; // Tiempo en segundos por cada dibujo


    float h;
    float v;

    [SerializeField] float speed = 3;
    [SerializeField] Transform aim;
    [SerializeField] new Camera camera;
    [SerializeField] int health = 5;

    Vector3 moveDirection;
    Vector2 facingDirection;

    [SerializeField] Transform bulletPrefab;

    bool gunLoaded = true;
    [SerializeField] float fireRate = 1;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(AnimarSprites());
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movimientoHorizontal * velocidadMovimiento * Time.deltaTime, 0f));

        // Actualiza la dirección del personaje
        if (movimientoHorizontal > 0)
        {
            direccion = 1;
        }
        else if (movimientoHorizontal < 0)
        {
            direccion = -1;
        }

        //Player movement
        h = Input.GetAxis("Horizontal");

        v = Input.GetAxis("Vertical");

        moveDirection.x = h;
        moveDirection.y = v;

        transform.position += moveDirection * Time.deltaTime * speed;

        //Aim movement

        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;
    
        //Bullets
        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Instantiate(bulletPrefab, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
            StartCoroutine(ReloadGun());
        }
    }
    void LateUpdate()
    {
        // Voltea el sprite según la dirección
        if (direccion == 1)
        {
            _spriteRenderer.flipX = true; // Sin volteo
        }
        else if (direccion == -1)
        {
            _spriteRenderer.flipX = false; // Volteo horizontal
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }

    IEnumerator AnimarSprites()
    {
        // Itera a través de cada sprite en el array
        for (int i = 0; i < sprites.Length; i++)
        {
            // Muestra el sprite actual
            _spriteRenderer.sprite = sprites[i];

            // Espera el tiempo especificado antes de pasar al siguiente sprite
            yield return new WaitForSeconds(tiempoPorFrame);
        }
    }
    public void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
