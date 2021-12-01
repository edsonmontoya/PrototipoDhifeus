using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject PanelInstrucciones;
    public bool menuEncendido;
    public bool instruccionesEncendido;


    public void ActivandoInstrucciones()
    {
        instruccionesEncendido =! instruccionesEncendido;
    }
    public void SaliendoInstrucciones()
    {
        instruccionesEncendido = false;
        menuEncendido = true;
    }
    public void Update()
    {
        if(instruccionesEncendido == true)
        {
            PanelInstrucciones.SetActive(true);
            menuEncendido = false;
        }
        if(instruccionesEncendido == false)
        {
            PanelInstrucciones.SetActive(false);
        }
        if (menuEncendido == true)
        {
            PanelMenu.SetActive(true);
        }
        if(menuEncendido == false)
        {
            PanelMenu.SetActive(false);
        }
    }
    public void IniciandoJuego()
    {
        SceneManager.LoadScene("PrototipoCombate");
    }
}
