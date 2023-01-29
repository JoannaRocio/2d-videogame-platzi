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

    Vector3 moveDirection;
    Vector2 facingDirection;

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
    
    }
}
