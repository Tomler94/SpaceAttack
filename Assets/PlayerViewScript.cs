using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
    }
}
