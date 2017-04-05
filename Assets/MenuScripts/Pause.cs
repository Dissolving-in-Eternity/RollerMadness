using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEditor;

public class Pause : MonoBehaviour
{
    //Делает видимым и доступным для выбора холст "пауза" в редакторе 
    public GameObject pauseObject;
    //Делает видимым и доступным для выбора холст со счётом монет в редакторе
    public GameObject mainCanvas;
    //Делает видимым и доступным для выбора холст победы уровня в редакторе
    public GameObject winCanvas;
    //Делает видимым и доступным для выбора холст проигрыша уровня в редакторе
    public GameObject looseCanvas;

    public void Update()
    {
        //Если код клавиши соотсветсвует 'Esc' и нет активных конфликтующих меню
        if ( (Input.GetKeyDown(KeyCode.Escape)) && !(winCanvas.activeSelf || looseCanvas.activeSelf) )
        {
            //Активируем холст "пауза"
            pauseObject.SetActive(true);
            //Деактивируем холст со счётом монет
            mainCanvas.SetActive(false);
            //Останавливаем время в игре
            Time.timeScale = 0f;
        }

        //Если код клавиши соотсветсвует 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResumeGameFunction();
        }        
    }

    //Функция, возобновляющая игру
    public void ResumeGameFunction()
    {
        pauseObject.SetActive(false);
        mainCanvas.SetActive(true);
        Time.timeScale = 1.0f;
    }
}

