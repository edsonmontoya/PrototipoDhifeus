using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpcionesDhifeus : MonoBehaviour
{
    public GameObject Opciones;
    public bool OpcionesEncendido;
    public bool PerdisteEncendido;
    public GameObject perdiste;
    public GameObject Habilidades;
    public bool habilidadesEncedido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpcionesEncendido = !OpcionesEncendido;
        }
        if (OpcionesEncendido == true)
        {
            Opciones.SetActive(true);
        }
        if (OpcionesEncendido == false)
        {
            Opciones.SetActive(false);
        }
        if (PerdisteEncendido == true)
        {
            OpcionesEncendido = false;
            perdiste.SetActive(true);
        }
        if(habilidadesEncedido == true)
        {
            OpcionesEncendido = false;
            Habilidades.SetActive(true);
        }
        if(habilidadesEncedido == false)
        {
            Habilidades.SetActive(false);
        }
        
    }
    public void cuandoQuieroIrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CuandoQuieroCerrarHabilidades()
    {
        habilidadesEncedido = false;
    }


}
