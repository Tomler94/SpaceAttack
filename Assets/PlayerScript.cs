using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //скорость
    public float speed;

    //Границы для starship
    public float xMin, xMax, zMin, zMax;

    //вращение 
    public float tilt;

    //Объект лазер
    public GameObject ShotOsn;
    public GameObject ShotDop1;
    public GameObject ShotDop2;

    //Пушки
    public Transform GunPosition;
    public Transform GunPosition1;
    public Transform GunPosition2;

    //Время перезарядки
    public float shotDelay;

    //Создание очередности выстрелов
    private float nextShot;

    //Булевая переменная для чередования выстрелов
    private int checker;

    //Проверка на запуск игры + чекер для пушек
    private GameControllerScript controller;
    private void Start()
    {
        controller = GameObject
                 .FindGameObjectWithTag("GameController")
                 .GetComponent<GameControllerScript>();
        checker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Если игра не запущено, то повторить 
        if (!controller.isGameStarted())
        {
            return;
        }

        //Основной огонь!

        if (Input.GetButton("Fire1") && Time.time > nextShot)
        {
                nextShot = Time.time + shotDelay;
                Instantiate(ShotOsn, GunPosition.position, Quaternion.identity);
        }

        //ОГОНЬ с проверкой на нажатие кнопки(Доп.пушки)
        if (Input.GetButton("Fire2") && Time.time > nextShot)
        {
            if (checker == 0)
            {
                
            
                nextShot = Time.time + shotDelay/2;
                Instantiate(ShotDop1, GunPosition1.position, Quaternion.identity);
                checker = 1;
            }
        
            else
            {
               nextShot = Time.time + shotDelay/2;
               Instantiate(ShotDop2, GunPosition2.position, Quaternion.identity);
               checker = 0;
            }
        }




        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody Player = GetComponent<Rigidbody>();
        // Скорость перемещения с направлением
        Player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        //Ограничивание значение 
        float newx = Mathf.Clamp(Player.position.x, xMin, xMax);
        float newz = Mathf.Clamp(Player.position.z, zMin, zMax);
        float newy = Player.position.y;

        Player.position = new Vector3(newx, newy, newz);
        //Quaternion задает вращение
        Player.rotation = Quaternion.Euler(Player.velocity.z * tilt, 0, -Player.velocity.x * tilt);
    }
}