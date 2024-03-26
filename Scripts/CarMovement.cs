using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationspeed = 100f;
    private Rigidbody myrigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        // Obtener la entrada del jugador
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Calcular el movimiento y la rotación
        Vector3 movement = transform.forward * speed * moveInput * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, rotateInput * rotationspeed * Time.deltaTime, 0f);

        // Aplicar movimiento y rotación al Rigidbody
        myrigidbody.MovePosition(myrigidbody.position + movement);
        myrigidbody.MoveRotation(myrigidbody.rotation * rotation);
    }
}
