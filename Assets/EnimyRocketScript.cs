using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyRocketScript : MonoBehaviour
{
    //Фиксированное значение скорости для астероидов
    public float Speed;
    //Добавление анимации эффектов взрыва
    public GameObject AsteroidExplosion;
    public GameObject ShipExplosion;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    // Update is called once per frame
    void Update()
    {
            GetComponent<Rigidbody>().velocity = transform.forward * Speed * 2;
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
                .IncreaseScore(150);
        }
        Instantiate(ShipExplosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
