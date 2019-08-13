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
            Vector3 posOffset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

            var obj = Instantiate(Prefab, tf.position + posOffset, tf.rotation);
            obj.GetComponent<Targeting>().Target = Player;
        }
        spawnerCharge -= toSpawn;
    }
}
