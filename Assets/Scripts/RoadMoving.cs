using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public float speed = 5f;  // Velocidad a la que se mueve la carretera

    public bool isGrass;

    public Transform spawnPositionGrass;
    // Tamaño de cada segmento de carretera en el eje Y
    public float segmentHeight = 6f;

    void Update()
    {
        // Movimiento hacia abajo de la carretera
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Si la carretera sale de la pantalla, reseteamos su posición
        if (transform.position.y < -segmentHeight)
        {
            ResetPosition();
        }
    }

    // Reseteamos la posición de la carretera
    void ResetPosition()
    {
        if (isGrass)
        {
            transform.position = spawnPositionGrass.position;
        }
        else
        {
            // La carretera debería reciclarse justo en la parte superior de la pantalla
            // Asumiendo que el punto inicial cuando la carretera está completamente visible es en y=0
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            Debug.Log("Reseteando posición a: " + transform.position);
        }
    }
}
