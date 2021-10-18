using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    // Variable de tipo Vector en 2D para la sensibilidad
    public Vector2 sensibility;
    // Variables que establecen la rotacion minima y maxima de la camara
    public float rotMin = -80;
    public float rotMax = 80;
    public float run;
    public float runLeft;
    public Joystick movJoy;
    public Joystick camJoy;

    // Variable para la velocidad del personaje
    private float speed = 7f;
    // Variable para guardar el Transform (posision y rotacion) de un objeto y el componente Rigidbody (fisicas) del objeto con este script
    private Transform Camera;
    private Rigidbody Physics;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Bloquea y hace invisible al cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        // Busca el transform de un objeto con el tag "PlayerCamera" dentro del objeto con este script
        Camera = transform.Find("PlayerCamera");
        // Busca el componente Rigidbody del objeto con este script
        Physics = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine == false);
        {
            return;
        }
        // Movimiento del personaje
        float ejeX = movJoy.Horizontal;
        float ejeZ = movJoy.Vertical;
        float rotationX = camJoy.Horizontal * sensibility.x;
        float rotationY = camJoy.Vertical * sensibility.y;

        transform.Translate(new Vector3(ejeX, 0.0f, ejeZ) * Time.deltaTime * speed);
        
        // Si la variable rotationX es diferente a 0
        if(rotationX != 0)
        {
            // Rota al objeto con este script y todos sus componentes en el eje y
            transform.Rotate(Vector3.up * rotationX * Time.deltaTime);
        }
        // Si la variable rotationY es diferente a 0
        if(rotationY != 0)
        {
            // Rota al objeto guardado en Camera delimitandolo a las variables rotMin y rotMax
            float angle = (Camera.localEulerAngles.x - rotationY + 360) % 360;
            if(angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -rotMax, rotMax);
            Camera.localEulerAngles = Vector3.right * angle;
        }
    }
}
