using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedSpawner : MonoBehaviour
{
    public float EnemiesPerSecond;
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
            var obj = Instantiate(Prefab, tf.position, tf.rotation);
            var move = obj.GetComponent<MoveTowardsPlayer>();
            move.Player = Player;
        }
        spawnerCharge -= toSpawn;
    }
}
