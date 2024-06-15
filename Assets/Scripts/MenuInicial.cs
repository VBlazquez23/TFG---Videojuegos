using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public Slider masterVolume;
    public Slider effectsVolume;
    public Slider musicVolume;

    public AudioMixer audioMixer;

    void Start()
    {
        float masterVol = PlayerPrefs.GetFloat("MasterVolume");     //Variable temporal para almacenar el valor guardado en el sistema con key "MasterVolume"
        masterVolume.value = masterVol;                                 //Asignamos la variable anterior y la asignamos al valor del slider (Posicion del slider)
        audioMixer.SetFloat("Master", masterVol);                  //Seteamos en AudioMixer a la clave "Master" el valor guardado en la variable del sistema
        
        float effectVol = PlayerPrefs.GetFloat("EffectsVolume");    //Variable temporal para almacenar el valor guardado en el sistema con key "EffectsVolume" 
        effectsVolume.value = effectVol;                                //Asignamos la variable anterior y la asignamos al valor del slider (Posicion del slider)
        audioMixer.SetFloat("Effects", effectVol);                 //Seteamos en AudioMixer a la clave "Effects" el valor guardado en la variable del sistema
        
        float musicVol = PlayerPrefs.GetFloat("MusicVolume");       //Variable temporal para almacenar el valor guardado en el sistema con key "MusicVolume"
        musicVolume.value = musicVol;                                   //Asignamos la variable anterior y la asignamos al valor del slider (Posicion del slider)
        audioMixer.SetFloat("Music", musicVol);                    //Seteamos en AudioMixer a la clave "Music" el valor guardado en la variable del sistema
    }
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //Cargamos la escena siguiente con la jerarquia de escenas configuradas (1 = escena de juego)
    }

    public void Salir()
    {
        Debug.Log("Salir...");          //Para comprobar que el boton funciona antes de crear la aplicacion y saber que saldrá
        Application.Quit();
    }

    public void SavedMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);   //Guardamos el valor del slider Master en el sistema para mantener cambios personalizados (Aunque el juego se cierre)
        audioMixer.SetFloat("Master", masterVolume.value);     //Seteamos el valor anterior en el audiomixer, para que surja efecto

    }
    public void SavedMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume.value );    //Guardamos el valor del slider Musica en el sistema para mantener cambios personalizados (Aunque el juego se cierre)
        audioMixer.SetFloat("Music", musicVolume.value);       //Seteamos el valor anterior en el audiomixer, para que surja efecto

    }
    public void SavedEffectsVolume()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume.value ); //Guardamos el valor del slider de Efectos en el sistema para mantener cambios personalizados (Aunque el juego se cierre)
        audioMixer.SetFloat("Effects", effectsVolume.value);     //Seteamos el valor anterior en el audiomixer, para que surja efecto

    }
}
