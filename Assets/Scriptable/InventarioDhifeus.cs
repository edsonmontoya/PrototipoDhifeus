using System.Collections.Generic;
using UnityEngine;
using System;

public class InventarioDhifeus : MonoBehaviour
{
    [SerializeField] List<Objetos> listaObjetos;
    public Transform objetosHijos;
    [SerializeField] SlotsObjetos[] slotsObjetos;
    public event Action<SlotsObjetos> OnPointerEnterEvent;
    public event Action<SlotsObjetos> OnPointerExitEvent;
    public event Action<SlotsObjetos> OnRightClickEvent;
    public event Action<SlotsObjetos> OnBeginDragEvent;
    public event Action<SlotsObjetos> OnEndDragEvent;
    public event Action<SlotsObjetos> OnDragEvent;
    public event Action<SlotsObjetos> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            slotsObjetos[i].OnPointerEnterEvent += OnPointerEnterEvent;
            slotsObjetos[i].OnPointerExitEvent += OnPointerExitEvent;
            slotsObjetos[i].OnRightClickEvent += OnRightClickEvent;
            slotsObjetos[i].OnBeginDragEvent += OnBeginDragEvent;
            slotsObjetos[i].OnEndDragEvent += OnEndDragEvent;
            slotsObjetos[i].OnDragEvent += OnDragEvent;
            slotsObjetos[i].OnDropEvent += OnDropEvent;
        }
        ActualizandoUI();
    }
    private void OnValidate()
    {
        if (objetosHijos != null)
        {
            slotsObjetos = objetosHijos.GetComponentsInChildren<SlotsObjetos>();
        }
        ActualizandoUI();
    }

    //Establecemos la lista y la cantidad de slots asi como tambien la actualizacion de la lista
    private void ActualizandoUI()
    {
        int i = 0;
        for (; i < listaObjetos.Count && i < slotsObjetos.Length; i++)
        {
            slotsObjetos[i].Objeto = listaObjetos[i];
        }
        for (; i < slotsObjetos.Length; i++)
        {
            slotsObjetos[i].Objeto = null;
        }
    }
    //Agregamos los objetos, si esta lleno retorna falso
    public bool AgregarItem(Objetos Objeto)
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            if (slotsObjetos[i].Objeto == null)
            {
                slotsObjetos[i].Objeto = Objeto;
                return true;
            }
        }
        return false;
    }
    //Quitamos los objetos y actualizamos la lista
    public bool QuitarObjetos(Objetos Objeto)
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            if (slotsObjetos[i].Objeto == Objeto)
            {
                slotsObjetos[i].Objeto = null;
                return true;
            }
        }
        return false;
    }
    public bool estaLleno()
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            if (slotsObjetos[i].Objeto == null)
            {

                return false;
            }
        }
        return true;
    }
}
