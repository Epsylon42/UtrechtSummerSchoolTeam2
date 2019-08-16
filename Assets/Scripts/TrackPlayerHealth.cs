using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerHealth : MonoBehaviour
{
    public GameObject Player;

    private SimpleHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<SimpleHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        var health = Player.GetComponent<Health>();
        healthBar.UpdateBar(health.CurrentHealth, health.MaxHealth);
    }
}
