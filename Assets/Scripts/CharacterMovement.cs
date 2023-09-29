using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CharacterMovement : MonoBehaviour
{
    //Esta variable hará referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterInput characterInput;

    //Estas dos variables almacena las velocidades iniciales de movimiento y la rotación//
    public float speedMov = 5.0f;

    //Estas variables almacenan la velocidad de movimiento al cual necesitamos regresar//
    public float speed0;
    public float speedCouch;

    //variables de Fmod necesarios para el sonido
    public FMODUnity.EventReference m_EventPath;
    private FMOD.Studio.EventInstance walkSoundInstance;
    private bool isWalking = false; // Variable para controlar el estado de caminata


    // Start is called before the first frame update
    void Start()
    {
        speed0 = speedMov; //Inicializamos la velocidad del movimiento
        speedCouch = speedMov * 0.5f; //Inicializamos la velocidad del movimiento de cuándo esté agachado
    }

    void Update()
    {
        Movement();

        // Verifica si el personaje está caminando
        if (characterInput.x != 0 || characterInput.y != 0)
        {
            if (!isWalking)
            {
                // Si no está caminando, crea una nueva instancia y comienza la reproducción.
                walkSoundInstance = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
                walkSoundInstance.start();
                isWalking = true; // Actualiza el estado de caminata
            }
        }
        else
        {
            if (isWalking)
            {
                // Si estaba caminando, detiene el sonido y actualiza el estado de caminata
                walkSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                isWalking = false;
            }
        }
    }


    //Método que moverá y rotará a mi personaje al nuevo vector3 establecido normalizado//
    public void Movement()
    {
        //Queremos rotar o movernos dependiendo de x e y
        transform.Translate(characterInput.x * Time.deltaTime * speedMov, 0, characterInput.y * Time.deltaTime * speedMov);
    }
}
