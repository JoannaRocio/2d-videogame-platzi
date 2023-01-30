using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    float h;
    float v;

    [SerializeField] float speed = 3;
    [SerializeField] Transform aim;
    [SerializeField] Camera camera;
    [SerializeField] int health = 5;

    Vector3 moveDirection;
    Vector2 facingDirection;

    [SerializeField] Transform bulletPrefab;

    bool gunLoaded = true;
    [SerializeField] float fireRate = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
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
