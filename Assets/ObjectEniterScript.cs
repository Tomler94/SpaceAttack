using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEniterScript : MonoBehaviour
{
    public float minDelayAs;
    public float maxDelayAs;

    public float minDelayEn;
    public float maxDelayEn;

    public List<GameObject> asteroid;
    public List<GameObject> enimy;

    private float nextSpawnAs;
    private float nextSpawnEn;
    //Запуск игры по нажатию кнопки
    private GameControllerScript controller;

    public GameObject Player;

    private void Start()
    {
      controller = GameObject
               .FindGameObjectWithTag("GameController")
               .GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGameStarted())
        {
            return;
        }

        if (GameObject.Find("Player") == null)
        {
            return;
        }

        if (Time.time > nextSpawnAs || Time.time > nextSpawnEn)
        {
            float XPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Vector3 Position = new Vector3(XPosition, transform.position.y, transform.position.z);
            int randomObject = Random.Range(0, 4);
 
            //Пришло время запускать астероиды
            if (randomObject >= 1 && randomObject <= 4)
            { Instantiate(asteroid[Random.Range(0, asteroid.Count)], Position, Quaternion.identity); } 

            //Пришло время запускать ОХОТНИКОВ
            if (Time.time > nextSpawnAs && randomObject == 0)
                        { Instantiate(enimy[Random.Range(0, enimy.Count)], Position, Quaternion.identity); }

            nextSpawnAs = Time.time + Random.Range(minDelayAs, maxDelayAs);
            nextSpawnEn = Time.time + Random.Range(minDelayEn, maxDelayEn);
        }
    }
}
