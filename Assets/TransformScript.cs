using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player") == null)
        {
            return;
        }
            player = GameObject.Find("Player");
            transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            return;
        }
        player = GameObject.Find("Player");
            transform.LookAt(player.transform);
    }
}
