using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_menu : MonoBehaviour
{
    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
    public void Salir()
    
        {
        Application.Quit();
        Debug.Log("se cierra xd");
    }

}
