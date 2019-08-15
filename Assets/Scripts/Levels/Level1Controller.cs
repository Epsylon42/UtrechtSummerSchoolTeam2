using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1Controller : MonoBehaviour
{
    public List<GameObject> RandomDasherSpawners;
    public List<GameObject> RushSpawners;
    public GameObject BossSpawner;
    public GameObject LightSource;
    public GameObject Player;

    public GameObject Music;

    private float timeElapsed = 0;
    private float stage = 0;

    private void Advance()
    {
        stage += 1;
        timeElapsed = 0;
    }

    private void ConfigRushSpawners(bool enabled, float enemiesPerSecond = 0)
    {
        foreach (var spawner in RushSpawners)
        {
            var spawn = spawner.GetComponent<RepeatedSpawner>();
            spawn.EnemiesPerSecond = enemiesPerSecond / RushSpawners.Count;
            spawn.Enabled = enabled;
        }
    }

    private void ConfigDasherSpawners(bool enabled, float enemiesPerSecond = 0)
    {
        foreach (var spawner in RandomDasherSpawners)
        {
            var spawn = spawner.GetComponent<RepeatedSpawner>();
            spawn.EnemiesPerSecond = enemiesPerSecond / RandomDasherSpawners.Count;
            spawn.Enabled = enabled;
        }
    }

    void Start()
    {
        Music.GetComponent<Level1Music>().PlayTutorialMusic();

        var spawners = new List<GameObject>();
        spawners.AddRange(RandomDasherSpawners);
        spawners.AddRange(RushSpawners);

        foreach (var spawner in spawners)
        {
            spawner.GetComponent<RepeatedSpawner>().Player = Player;
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        switch (stage)
        {
            case 0:
                ConfigDasherSpawners(false);
                ConfigRushSpawners(true, 0.5f);
                Advance();
                break;

            case 1:
                if (timeElapsed > 10)
                {
                    ConfigDasherSpawners(true, 0.5f);
                    ConfigRushSpawners(true, 1);
                    Advance();
                }
                break;

            case 2:
                if (timeElapsed > 20)
                {
                    LightSource.GetComponent<Light>().intensity /= 3;

                    ConfigDasherSpawners(false);
                    ConfigRushSpawners(true, 2);
                    Music.GetComponent<Level1Music>().PlayLevelMusic();
                    Advance();
                }
                break;

            case 3:
                if (timeElapsed > 20)
                {
                    ConfigDasherSpawners(true, 2);
                    ConfigRushSpawners(true, 1);
                    Advance();
                }
                break;

            case 4:
                if (timeElapsed > 20)
                {
                    ConfigDasherSpawners(false);
                    ConfigRushSpawners(false);
                    Music.GetComponent<Level1Music>().SetVolume(0.3f);
                    Advance();
                }
                break;

            case 5:
                if (timeElapsed > 10)
                {
                    ConfigDasherSpawners(true, 1);

                    Music.GetComponent<Level1Music>().PlayBossMusic();
                    Music.GetComponent<Level1Music>().SetVolume(1);

                    var boss = BossSpawner.GetComponent<RepeatedSpawner>().SpawnOnce();
                    boss.GetComponent<Transform>().LookAt(
                        Player.GetComponent<Transform>().position,
                        Vector3.forward
                        );
                    var tf = boss.GetComponent<Transform>();
                    var dir = (tf.position - Player.GetComponent<Transform>().position).normalized;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    tf.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    boss.GetComponentInChildren<Health>().OnHealthBelowZero = () => {
                        Debug.Log("You Win!");
                    };

                    Advance();
                }
                break;

            default:
                break;
        }
    }
}
