using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // Arrastra aquí el prefab de la moneda
    public float spawnInterval = 3f;  // Intervalo entre generación de monedas
    private float[] lanes = { -2f, -0.68f, 0.68f, 2f };  // Posiciones X para los carriles de aparición

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()        //Corrutina que spawnea monedas
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); //configura el intervalo de spawn de monedas.
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int randomLaneIndex = Random.Range(0, lanes.Length);
        float spawnY = 6f;  // Altura Y en la que aparecerán las monedas
        Vector3 spawnPosition = new Vector3(lanes[randomLaneIndex], spawnY, 0);     //Asignamos las posiciones validad de la moneda (los 4 carriles de la carretera)
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);    //Instancia el prefab de la moneda en la posicion dada (spawn position).
    }
}