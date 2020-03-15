using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;

    private GameControllerScript controller;
    private void Start()
    {
        controller = GameObject
                 .FindGameObjectWithTag("GameController")
                 .GetComponent<GameControllerScript>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGameStarted())
        {
            return;
        }

        //как быстро изменяется с течением времени, длина background 
        float newPosition = Mathf.Repeat(Time.time*speed,transform.localScale.y);
        transform.position = startPosition + Vector3.back * newPosition;
    }
}
