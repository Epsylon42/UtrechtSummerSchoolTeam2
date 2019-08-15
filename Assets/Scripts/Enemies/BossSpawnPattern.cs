using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnPattern : MonoBehaviour
{
    public GameObject RushSpawner_;

    private RepeatedSpawner RushSpawner;
    private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        RushSpawner = GetComponentInChildren<RepeatedSpawner>();
        RushSpawner.Enabled = true;
        RushSpawner.EnemiesPerSecond = 5;
        RushSpawner.Player = GetComponent<Targeting>().Target;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > 5)
        {
            RushSpawner.EnemiesPerSecond = 1;
            Destroy(this);
        }
    }
}
