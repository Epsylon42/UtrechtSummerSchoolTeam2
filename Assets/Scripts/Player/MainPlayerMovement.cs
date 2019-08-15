using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 accelaration = Vector2.zero;
        bool movement = false;

        if(Input.GetKey(KeyCode.D))
        {
            accelaration.x += 1;
            movement = true;
        }

        if(Input.GetKey(KeyCode.W))
        {
            accelaration.y += 1;
            movement = true;
        }

        if(Input.GetKey(KeyCode.S))
        {
            accelaration.y -= 1;
            movement = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            accelaration.x -= 1;
            movement = true;
        }

        accelaration.Normalize();

        rb.velocity = accelaration * speed;

        if (movement)
        {
            anim?.SetBool("Walk_Anim", true);
        }
        else
        {
            anim?.SetBool("Walk_Anim", false);
        }
    }
}
