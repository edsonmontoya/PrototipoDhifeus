using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsAccesoDirecto : SlotsObjetos
{
    public TipoAcceso tipoAcceso;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = tipoAcceso.ToString() + "SlotAcceso";
    }
    public override bool PuedeRecibirObjeto(Objetos objeto)
    {
        if (objeto == null)
        {
            return true;
        }
        HabilidadAAcceso habilidadAAcceso = objeto as HabilidadAAcceso;
        return habilidadAAcceso != null && habilidadAAcceso.tipoAcceso == tipoAcceso;
    }
}


