using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Exit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}