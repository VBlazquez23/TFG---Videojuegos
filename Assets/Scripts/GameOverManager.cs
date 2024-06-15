using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    

    //Método que reinicia la escena de juego
    public void ResetearJuego()
    {
        Time.timeScale = 1;                 //Tras la colision, el tiempo estaba en 0. Esto lo situa de nuevo en tiempo normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
    //Método para salir del juego
    public void Salir()
    {
        Application.Quit();
    }
    
    //Método que lleva al menu inicial de nuevo
    public void MenuInicial()
    {
        Time.timeScale = 1;                                                     //Volver al tiempo de juego normal. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);   //Carga la escena anterior en la jerarquia configurada (Menu ininial tiene index = 0)
    }
}
