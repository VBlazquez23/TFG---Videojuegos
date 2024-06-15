using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Velocidad de movimiento del coche
    public float speed = 6f;
    // Límite en el eje X para el movimiento del coche, ya que se mueve lateralmente a lo largo de este eje
    public float xLimit = 2f;

    // Update is called once per frame
    void Update()
    {
        // Obtener el input horizontal (teclas A y D o flechas izquierda y derecha)
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Calcular el nuevo movimiento del coche en el eje X
        Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        
        // Mover el coche
        transform.Translate(movement, Space.World);

        // Limitar el movimiento del coche en el eje X
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xLimit, xLimit);
        transform.position = clampedPosition;
    }
}