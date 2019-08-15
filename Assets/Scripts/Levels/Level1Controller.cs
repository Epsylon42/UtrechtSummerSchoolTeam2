using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1Controller : MonoBehaviour
{
    public GameObject RandomDasherSpawner_;
    public GameObject RushSpawner_;
    public GameObject BossSpawner;
    public GameObject LightSource;
    public GameObject Player;

    public GameObject Music;

    private float timeElapsed = 0;
    private float stage = 0;

    private RepeatedSpawner RandomDasherSpawner;
    private RepeatedSpawner RushSpawner;

    private void Advance()
    {
        stage += 1;
        timeElapsed = 0;
    }

    void Start()
    {
        Music.GetComponent<Level1Music>().PlayTutorialMusic();
        RandomDasherSpawner = RandomDasherSpawner_.GetComponent<RepeatedSpawner>();
        RushSpawner = RushSpawner_.GetComponent<RepeatedSpawner>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        switch (stage)
        {
            case 0:
                RandomDasherSpawner.Enabled = false;
                RushSpawner.EnemiesPerSecond = 0.5f;
                Advance();
                break;

            case 1:
                if (timeElapsed > 10)
                {
                    RushSpawner.EnemiesPerSecond = 1;
                    RandomDasherSpawner.Enabled = true;
                    RandomDasherSpawner.EnemiesPerSecond = 0.5f;
                    Advance();
                }
                break;

            case 2:
                if (timeElapsed > 20)
                {
                    LightSource.GetComponent<Light>().intensity /= 3;

                    RandomDasherSpawner.Enabled = false;
                    RushSpawner.EnemiesPerSecond = 3;
                    Music.GetComponent<Level1Music>().PlayLevelMusic();
                    Advance();
                }
                break;

            case 3:
                if (timeElapsed > 20)
                {
                    RandomDasherSpawner.Enabled = true;
                    RandomDasherSpawner.EnemiesPerSecond = 2;
                    RushSpawner.EnemiesPerSecond = 1;
                    Advance();
                }
                break;

            case 4:
                if (timeElapsed > 20)
                {
                    RandomDasherSpawner.Enabled = false;
                    RushSpawner.Enabled = false;
                    Music.GetComponent<Level1Music>().SetVolume(0.3f);
                    Advance();
                }
                break;

            case 5:
                if (timeElapsed > 10)
                {
                    RandomDasherSpawner.Enabled = false;
                    RushSpawner.Enabled = false;
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
