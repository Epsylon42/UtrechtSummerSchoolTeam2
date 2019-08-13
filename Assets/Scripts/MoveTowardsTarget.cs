using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var directionToTarget =
            GetComponent<Targeting>()
            .Target
            .GetComponent<Transform>()
            .position - GetComponent<Transform>().position;

        var velocity = directionToTarget.normalized * Speed;
        body.velocity = velocity;
    }
}
