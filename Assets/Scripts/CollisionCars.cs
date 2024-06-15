using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class CollisionCars : MonoBehaviour
{
    [FormerlySerializedAs("timerController")] public TimeController timeController;
    private int score = 0;
    public TextMeshProUGUI txtCoins;
    public TextMeshProUGUI txtScore;
    public GameObject gameOverPanel;
    public TextMeshProUGUI txtGameOverScore;
    public AudioSource audioManager;
    public AudioSource audioMusica;
    public AudioClip clipMoneda;
    public AudioClip clipChoque;

    void OnTriggerEnter2D(Collider2D other)            // Disparador para dectar cuando colisionamos con coche o monedas. Sin fisicas
    {   
        if (other.gameObject.CompareTag("Coin"))       // Colisionamos con monedas, y las añadimos al contador
        {
            audioManager.clip = clipMoneda;
            audioManager.Play();
            score += 100;
            txtScore.text = score.ToString();
            Destroy(other.gameObject);                 // Destruimos la moneda para que desaparezca
        }
        if (other.gameObject.CompareTag("EnemyCar"))   // Colisionamos con un vehiculo y Game Over
        {
            audioManager.clip = clipChoque;
            audioManager.Play();            
            timeController.StopTimer();            // Paramos el tiempo
            txtGameOverScore.text = "Puntuacion: " + score.ToString() + "        Tiempo: " + timeController.timerText.text ;
            txtScore.gameObject.SetActive(false);
            txtCoins.gameObject.SetActive(false);
            timeController.timerText.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);          // Esto nos activa el panel que tenemos desactivado por defecto
            Time.timeScale = 0;                     // Detiene el tiempo en el juego
            audioMusica.Stop();
            Debug.Log("GAME OVER");
        }
        else
        {
            Debug.Log("Collided with: " + other.gameObject.tag); // Esto ayudará a identificar si hay un problema con los tags
        }
    }
}