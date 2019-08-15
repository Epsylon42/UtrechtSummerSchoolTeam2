using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Dashing,
    Idle,
}

public class RandomDashing : MonoBehaviour
{
    public Vector2 DashDistanceRange;
    public Vector2 DashSpeedRange;
    public float IntervalBetweenDashes;
    public float TargetDirectionWeight = 0;

    private float time = 0;
    private State state = State.Idle;

    void Update()
    {
        if (state == State.Idle)
        {
            time += Time.deltaTime;
            if (time >= IntervalBetweenDashes)
            {
                StartCoroutine(Dash());
            }
        }

    }

    IEnumerator Dash()
    {
        state = State.Dashing;

        var distance = Random.Range(DashDistanceRange.x, DashDistanceRange.y);
        var speed = Random.Range(DashDistanceRange.x, DashDistanceRange.y);

        var angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2 targetDirection =
            (Vector2)(GetComponent<Targeting>()
            .Target
            .GetComponent<Transform>()
            .position - GetComponent<Transform>().position).normalized;

        float dashState = 0;
        while (dashState < distance)
        {
            dashState += Time.deltaTime * speed;
            GetComponent<Rigidbody2D>().position += (direction * (1 - TargetDirectionWeight) + targetDirection * TargetDirectionWeight) * Time.deltaTime * speed;
            yield return null;
        }

        time = 0;
        state = State.Idle;
    }
}
