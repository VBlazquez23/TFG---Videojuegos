using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime;
    private bool isRunning = true;

    //Inicia el tiempo de juego
    void Start()
    {           
        startTime = Time.time;
    }

    //Actualiza el texto de tiempo de forma constante con el tiempo del sistema
    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00.0");
            timerText.text = minutes + ":" + seconds;
        }
    }

    //Para el tiempo, ocurre cuando colisionamos o pausamos el juego.
    public void StopTimer()
    {
        isRunning = false;
    }

    // Método público para acceder a startTime desde otros scripts
    public float GetStartTime()
    {
        return startTime;
    }
}