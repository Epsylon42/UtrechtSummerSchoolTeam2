using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float Speed;
    public GameObject Player;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var directionToPlayer = Player.GetComponent<Transform>().position - GetComponent<Transform>().position;
        var velocity = directionToPlayer.normalized * Speed;
        body.velocity = velocity;
    }
}
