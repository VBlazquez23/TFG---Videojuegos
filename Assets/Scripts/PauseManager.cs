using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    public AudioSource pauseSound;
    // Update is called once per frame
    void Update()
    {
     //Capturamos la tecla P o Escape para pausar el juego o reanudarlo si está pausado
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(!pausePanel.activeSelf);       //Niega el estado actual, es decir si esta activo lo desactiva y viceversa.
            if (pausePanel.activeSelf == true)
            {
                Time.timeScale = 0;                             //Para el tiempo de juego y la música cuando se pausa
                pauseSound.Pause();
            }
            else
            {
                Time.timeScale = 1;                             //Reanuda el tiempo de juego y la musica cuando se vouelve de pause (Unpause)
                pauseSound.UnPause();
            }
        }
    }

    public void ResetearJuego()
    {
        Time.timeScale = 1;                                                 //tras la pausa, reanudamos el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Carga la misma escena que la actual, porque es la de juego
    }
        

    public void Salir()
    {
        Application.Quit();
    }

    public void MenuInicial()
    {
        Time.timeScale = 1;                                                   //tras la pausa, reanudamos el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Carga la escena anterior a la actual (1), que es 0 en la jerarquía.
    }
}
