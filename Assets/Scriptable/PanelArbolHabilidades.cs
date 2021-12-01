using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelArbolHabilidades : MonoBehaviour
{
    [SerializeField] List<CaracteristicasDhifeus> listaHabilidades;
    public Transform habilidadesHijos;
    [SerializeField] MostradorHabilidades[] mostradorHabilidades;
    // Start is called before the first frame update


    private void OnValidate()
    {
        if (habilidadesHijos != null)
        {
            mostradorHabilidades = habilidadesHijos.GetComponentsInChildren<MostradorHabilidades>();
        }
        ActualizandoUIArbol();
    }

    private void ActualizandoUIArbol()
    {
        int i = 0;
        for (; i < listaHabilidades.Count && i < mostradorHabilidades.Length; i++)
        {
            mostradorHabilidades[i].caracteristicasDhifeus = listaHabilidades[i];
        }
        for (; i < mostradorHabilidades.Length; i++)
        {
            mostradorHabilidades[i].caracteristicasDhifeus = null;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
