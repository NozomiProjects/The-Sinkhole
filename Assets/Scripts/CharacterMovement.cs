using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Esta variable hará referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterInput characterInput;

    //Estas dos variables almacena las velocidades iniciales de movimiento y la rotación//
    public float speedMov = 5.0f;

    //Estas variables almacenan la velocidad de movimiento al cual necesitamos regresar//
    public float speed0;
    public float speedCouch;

    // Start is called before the first frame update
    void Start()
    {
        speed0 = speedMov; //Inicializamos la velocidad del movimiento
        speedCouch = speedMov * 0.5f; //Inicializamos la velocidad del movimiento de cuándo esté agachado
    }

    //Método que moverá y rotará a mi personaje al nuevo vector3 establecido normalizado//
    public void Movement()
    {
        //Queremos rotar o movernos dependiendo de x e y
        transform.Translate(characterInput.x * Time.deltaTime * speedMov, 0, characterInput.y * Time.deltaTime * speedMov);
    }
}
