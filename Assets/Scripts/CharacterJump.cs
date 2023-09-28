using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    //Esta variable hará referencia al objeto que contiene el Rigidbody que necesitemos acceder//
    public Rigidbody rb;

    //Esta variable almacenará la fuerza del salto//
    public float forceJump = 40f;
    //Esta variable almacenará un booleano que indica si el salto se puede ejecutar o no//
    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false; //Inicializamos la variable en false
    }

    //Método que ejecutará el movimiento de salto del personaje//
    public void Jump()
    {
        rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse); //Al rigidbody del personaje se le agrega una fuerza en el eje Y
    }
}
