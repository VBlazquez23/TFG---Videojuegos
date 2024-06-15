using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class EnemyCarMovement : MonoBehaviour
 {
     public float speed = 5f;  // Velocidad inicial del vehículo. Se puede modificar en unity y se modifica automáticamente con el incremento de nivel.
 
     // Método público para ajustar la velocidad del vehículo desde otros scripts
     public void SetSpeed(float newSpeed)
     {
         speed = newSpeed;
     }
 
     void Update()
     {
         // Mover el vehículo hacia la derecha en el eje X (vehículo rotado 90º)
         transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
 
         // Destruir el vehículo si sale de la pantalla (en y = -6)
         if (transform.position.y <= -6)
         {
             Destroy(gameObject);
         }
     }
 }