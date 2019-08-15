using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public float Speed;
    public float TrajectoryUpdateInterval = 0;

    private Rigidbody2D body;
    private float timeElapsed = 0;
    private Vector2 currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        UpdateTrajectory();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= TrajectoryUpdateInterval)
        {
            timeElapsed = 0;
            UpdateTrajectory();
        }

        body.velocity = currentDirection * Speed;
    }

    void UpdateTrajectory()
    {
        currentDirection =
            GetComponent<Targeting>()
            .Target
            .GetComponent<Transform>()
            .position - GetComponent<Transform>().position;

        currentDirection.Normalize();
    }
}
