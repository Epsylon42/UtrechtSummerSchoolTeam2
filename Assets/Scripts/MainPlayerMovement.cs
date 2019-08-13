using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed; 
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        Vector2 accelaration = Vector2.zero;

        if(Input.GetKey(KeyCode.D)) 
            accelaration.x += 1;
        
        if(Input.GetKey(KeyCode.W))
            accelaration.y += 1;

        if(Input.GetKey(KeyCode.S))
            accelaration.y -= 1;

        if(Input.GetKey(KeyCode.A))
            accelaration.x -= 1;

        accelaration.Normalize();
        
        rb.velocity = accelaration * speed;
        
    }
}
