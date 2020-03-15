using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    // Связывание текста и контрольного поля
    public GameObject ScoreText;
    //Запуск игры по кнопке
    public GameObject startButton;
    //Меню 
    public GameObject Menu;
    // хронит кол-во очков
    public int score = 0;
    //Проверка запущена ли игра
    private bool isStarted = false;

    private void Start()
    {
        startButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            isStarted = true;
            Menu.SetActive(false);
        });
    }
    //Изменение кол-во очков
    public void IncreaseScore(int increment)
    {
        score += increment;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }

    public bool isGameStarted()
    {
        return isStarted;
    }
}
