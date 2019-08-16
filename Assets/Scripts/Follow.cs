using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Parent;

    private Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = GetComponent<Transform>().position - Parent.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Parent != null)
        {
            GetComponent<Transform>().position = Parent.GetComponent<Transform>().position + diff;
        }
        else
        {
            Destroy(this);
        }
    }
}
