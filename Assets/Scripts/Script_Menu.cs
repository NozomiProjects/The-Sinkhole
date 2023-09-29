using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
     public void EmpezarNivel (string Nivel1)
     {
        SceneManager.LoadScene(Nivel1);
     }

    public void Salir()
    {
        Application.Quit();
    }
}
