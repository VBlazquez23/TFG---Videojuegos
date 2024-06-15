using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehiclesPrefab;
    public float spawnRate = 6f;  // Tiempo entre spawns en segundos
    private float nextTimeToSpawn = 0f;
    private int speedEnemy = 2;
    private float[] lanes = { -2f, -0.68f, 0.68f, 2f };     //Posiciones en X (Los 4 carriles)

    void Start() 
    {
        nextTimeToSpawn = Time.time + spawnRate; // Inicializa la próxima vez para spawn
        StartCoroutine(IncreaseLevel());
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            SpawnVehicle();
            nextTimeToSpawn = Time.time + spawnRate;  // Asegura el control del tiempo de spawn. Tiempo transcurrido mas spawn rate (6 segundos o modificable)
            
        }
    }

    void SpawnVehicle()
    {
        int randomLane = Random.Range(0, lanes.Length);
        Vector3 spawnPosition = new Vector3(lanes[randomLane], 6, 0);        //Ajustamos la posicion del spawn (X=random, Y=6)
        GameObject carEnemy = Instantiate(vehiclesPrefab[Random.Range(0, vehiclesPrefab.Length)], spawnPosition, Quaternion.Euler(0, 0, -90));  //Spawn del vehiculo con la configuracion de rotacion 90º
        carEnemy.GetComponent<EnemyCarMovement>().SetSpeed(speedEnemy);            //Actualiza la velocidad del vehiculo que aparece nuevo
    }
    
    IEnumerator IncreaseLevel() 
    {
        yield return new WaitForSeconds(10);                                        //Esperamos 10 segundos en la corrutina (El nivel de dificultad se incrementará cada 10 segundos)
        speedEnemy += 1;                                                            //Controla el incremento de velocidad
        GameObject[] carsEnemy = GameObject.FindGameObjectsWithTag("EnemyCar");     //Busca todos los vehiculos con este tag, es decir los vehiculos enemigos.
        foreach(GameObject enemy in carsEnemy)                                      //Recorre todos los vehiculos encontrados y actualizamos este incremento de velocidad
        {
            enemy.GetComponent<EnemyCarMovement>().SetSpeed(speedEnemy);
        }
            
 
        StartCoroutine(IncreaseLevel());  //Para realizar bucle, que no se incremente solo una vez.
    }
    
}