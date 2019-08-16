using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentCameraOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().OnHealthBelowZero = () => {
            GetComponentInChildren<Camera>().transform.parent = null;
        };
    }
}
