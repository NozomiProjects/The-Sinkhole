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
    public FMODUnity.EventReference walkSoundEvent; // Evento de sonido de caminata
    public FMODUnity.EventReference jumpSoundEvent; // Evento de sonido de salto

    private FMOD.Studio.EventInstance walkSoundInstance; // Instancia de sonido de caminata
    private FMOD.Studio.EventInstance jumpSoundInstance; // Instancia de sonido de salto
    private bool isWalking = false; // Variable para controlar el estado de caminata


    // Start is called before the first frame update
    void Start()
    {
        speed0 = speedMov; //Inicializamos la velocidad del movimiento
        speedCouch = speedMov * 0.5f; //Inicializamos la velocidad del movimiento de cuándo esté agachado

        // Inicializa la instancia de sonido de salto
        jumpSoundInstance = FMODUnity.RuntimeManager.CreateInstance(jumpSoundEvent);
    }

    void Update()
    {
        Movement();

        if (characterInput.x != 0 || characterInput.y != 0)
        {
            if (!isWalking)
            {
                walkSoundInstance = FMODUnity.RuntimeManager.CreateInstance(walkSoundEvent);
                walkSoundInstance.start();
                isWalking = true;
            }
        }
        else
        {
            if (isWalking)
            {
                walkSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                isWalking = false;
            }
        }

        // Verifica si el jugador presiona el botón de salto (barra espaciadora)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Llama al método de salto en el script CharacterJump
            characterInput.characterJump.Jump();
            // Reproduce el sonido de salto
            jumpSoundInstance.start();
        }
    }


    //Método que moverá y rotará a mi personaje al nuevo vector3 establecido normalizado//
    public void Movement()
    {
        //Queremos rotar o movernos dependiendo de x e y
        transform.Translate(characterInput.x * Time.deltaTime * speedMov, 0, characterInput.y * Time.deltaTime * speedMov);
    }
}
