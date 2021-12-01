using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoAcceso 
{
    AplicaCuracion,
    AplicaCambioDeArma,
    Todas


}
[CreateAssetMenu]


public class HabilidadAAcceso : Objetos
{
    public int Damage;
    public int Curativo;
    public TipoAcceso tipoAcceso;


    public void SiEquipoAcceso(PersonajeDhifeus c)
    {




    }
    
    public void NoEquipoAcceso(PersonajeDhifeus c)
    {

    }
}
