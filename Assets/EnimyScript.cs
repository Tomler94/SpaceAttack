using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyScript : MonoBehaviour
{
    //Фиксированное значение скорости для астероидов
    public float Speed;
    //Добавление анимации эффектов взрыва
    public GameObject AsteroidExplosion;
    public GameObject ShipExplosion;
    public GameObject player;
    public Transform GunPosition;
    public GameObject ShotEnimy;
    private float nextShot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    void Update()
    {
        if (GameObject.Find("Player") != null)
        {

            player = GameObject.Find("Player");

            transform.LookAt(player.transform);

            if (Time.time > nextShot &&
                GameObject.Find("Player").transform.position.z + 5 < transform.position.z)
            {
                nextShot = Time.time + 1;
                Instantiate(ShotEnimy, GunPosition.position, Quaternion.identity);
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        }
    }
    // Когда объект сталкивается с текущим коллайдером
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Enimy" || other.tag == "EnimyShot")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(ShipExplosion, other.transform.position, other.transform.rotation);
        }
        if (other.tag == "Asteroid")
        {
            Instantiate(AsteroidExplosion, other.transform.position, other.transform.rotation);
        }
        if (other.tag == "Shot")
        {
            GameObject
                .FindGameObjectWithTag("GameController")
                .GetComponent<GameControllerScript>()
                .IncreaseScore(100);
        }
        Instantiate(ShipExplosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

