using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AasteroidScript : MonoBehaviour
{
    //Скорость углового вращения
    public float rotoshedSpeed;
    //Фиксированное значение скорости для астероидов
    public float minSpeed;
    public float maxSpeed;

    //Добавление анимации эффектов взрыва
    public GameObject AasteroidExplosion;
    public GameObject ShipExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        // позволяет сгенерировать случайные 3 числа углового вращения
        asteroid.angularVelocity = Random.insideUnitSphere * rotoshedSpeed;
        float napravleniex = Random.Range(-0.5f, 0.5f);
        float napravleniez = Random.Range(-0.5f, 0.5f);
        Vector3 polet = new Vector3(napravleniex, 0f, napravleniez);
        asteroid.velocity = polet * Random.Range(minSpeed, maxSpeed)*2;
    }

    // Когда объект сталкивается с текущим коллайдером
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary"|| other.tag == "Asteroid")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(ShipExplosion, other.transform.position, other.transform.rotation);
        }
        if (other.tag == "Shot")
        {
            GameObject
                .FindGameObjectWithTag("GameController")
                .GetComponent<GameControllerScript>()
                .IncreaseScore(50);
        }
        Instantiate(AasteroidExplosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
