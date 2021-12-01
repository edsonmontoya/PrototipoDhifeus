using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelAccesoDirecto : MonoBehaviour
{
    [SerializeField] Transform slotsEquipObjetosHijos;
    [SerializeField] SlotsAccesoDirecto[] slotsAccesoDirectos;
    public event Action<SlotsObjetos> OnPointerEnterEvent;
    public event Action<SlotsObjetos> OnPointerExitEvent;
    public event Action<SlotsObjetos> OnRightClickEvent;
    public event Action<SlotsObjetos> OnBeginDragEvent;
    public event Action<SlotsObjetos> OnEndDragEvent;
    public event Action<SlotsObjetos> OnDragEvent;
    public event Action<SlotsObjetos> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsAccesoDirectos.Length; i++)
        {
            slotsAccesoDirectos[i].OnPointerEnterEvent += OnPointerEnterEvent;
            slotsAccesoDirectos[i].OnPointerExitEvent += OnPointerExitEvent;
            slotsAccesoDirectos[i].OnRightClickEvent += OnRightClickEvent;
            slotsAccesoDirectos[i].OnBeginDragEvent += OnBeginDragEvent;
            slotsAccesoDirectos[i].OnEndDragEvent += OnEndDragEvent;
            slotsAccesoDirectos[i].OnDragEvent += OnDragEvent;
            slotsAccesoDirectos[i].OnDropEvent += OnDropEvent;
        }

    }
    private void OnValidate()
    {
        slotsAccesoDirectos = slotsEquipObjetosHijos.GetComponentsInChildren<SlotsAccesoDirecto>();
    }
    public bool AgregarHabilidad(HabilidadAAcceso Objeto, out HabilidadAAcceso objetoAnterior)
    {
        for (int i = 0; i < slotsAccesoDirectos.Length; i++)
        {
            if (slotsAccesoDirectos[i].tipoAcceso == Objeto.tipoAcceso)//OJO
            {
                objetoAnterior = (HabilidadAAcceso)slotsAccesoDirectos[i].Objeto;
                slotsAccesoDirectos[i].Objeto = Objeto;
                return true;
            }
        }
        objetoAnterior = null;
        return false;
    }
    public bool QuitarHabilidad(HabilidadAAcceso Objeto)
    {
        for (int i = 0; i < slotsAccesoDirectos.Length; i++)
        {
            if (slotsAccesoDirectos[i].Objeto == Objeto)
            {
                slotsAccesoDirectos[i].Objeto = null;
                return true;
            }
        }
        return false;
    }

}
