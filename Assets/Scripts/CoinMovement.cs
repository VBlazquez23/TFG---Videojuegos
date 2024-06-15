using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float speed = -2f;  // Aqui ajustamos la velocidad para que coincida con la carretera

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

        if (transform.position.y < -10) // Destruimos la moneda en esta posicion si no se recoge
        {
            Destroy(gameObject);
        }
    }
}