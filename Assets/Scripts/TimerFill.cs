using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFill : MonoBehaviour
{
    private SimpleHealthBar bar;

    public float Duration;
    private float time = 0;

    void Start()
    {
        bar = GetComponent<SimpleHealthBar>();
    }

    void Update()
    {
        time += Time.deltaTime;
        bar.UpdateBar(time, Duration);
        if (time > Duration)
        {
            Destroy(this);
        }
    }
}
