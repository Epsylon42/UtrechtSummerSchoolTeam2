using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedSpawner : MonoBehaviour
{
    public float EnemiesPerSecond;
    public Vector2 SpawnDistanceRange;
    public GameObject Prefab;
    public GameObject Player;
    public bool Enabled = true;

    private float spawnerCharge = 0.0f;

    void Update()
    {
        if (Enabled)
        {
            spawnerCharge += EnemiesPerSecond * Time.deltaTime;
        }

        int toSpawn = (int)Mathf.Floor(spawnerCharge);
        if (toSpawn > 1)
        {
            spawnerCharge += Random.Range(0, EnemiesPerSecond);
        }
        for (int i = 0; i < toSpawn; i++)
        {
            SpawnOnce();
        }
        spawnerCharge -= toSpawn;
    }

    public GameObject SpawnOnce()
    {
        var tf = GetComponent<Transform>();

        var distance = Random.Range(SpawnDistanceRange.x, SpawnDistanceRange.y);
        var angle = Random.Range(0, 2 * Mathf.PI);
        Vector3 posOffset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

        var obj = Instantiate(Prefab, tf.position + posOffset, Quaternion.identity);
        obj.GetComponent<Targeting>()?.SetTarget(Player);
        obj.GetComponent<Transform>().SetParent(null);


        return obj;
    }
}
