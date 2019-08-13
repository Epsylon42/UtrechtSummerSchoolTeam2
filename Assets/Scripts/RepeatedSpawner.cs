using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedSpawner : MonoBehaviour
{
    public float EnemiesPerSecond;
    public Vector2 SpawnDistanceRange;
    public GameObject Prefab;
    public GameObject Player;

    private float spawnerCharge = 0.0f;


    // Update is called once per frame
    void Update()
    {
        spawnerCharge += EnemiesPerSecond * Time.deltaTime;

        var tf = GetComponent<Transform>();

        int toSpawn = (int)Mathf.Floor(spawnerCharge);
        for (int i = 0; i < toSpawn; i++)
        {
            var distance = Random.Range(SpawnDistanceRange.x, SpawnDistanceRange.y);
            var angle = Random.Range(0, 2 * Mathf.PI);
            var posOffset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;

            var obj = Instantiate(Prefab, tf.position + posOffset, tf.rotation);
            var move = obj.GetComponent<MoveTowardsPlayer>();
            move.Player = Player;
        }
        spawnerCharge -= toSpawn;
    }
}
