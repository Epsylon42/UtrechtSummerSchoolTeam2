using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionOnDeath : MonoBehaviour
{
    public string SceneName;
    public float Delay;

    void Start()
    {
        GetComponentInChildren<Health>().OnHealthBelowZero += () => {
            SceneManager.LoadScene(SceneName);
            // StartCoroutine(changeSceneAfterDelay());
        };
    }

    private IEnumerator changeSceneAfterDelay()
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(SceneName);
    }
}
