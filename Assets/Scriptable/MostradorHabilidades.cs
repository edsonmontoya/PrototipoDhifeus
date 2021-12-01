using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MostradorHabilidades : MonoBehaviour
{
    public CaracteristicasDhifeus _caracteristicasDhifeus;
    public Image imagenHabilidad;


    private Color colorNormal = Color.white;
    private Color disableColor = new Color(1, 1, 1, 0);
    public CaracteristicasDhifeus caracteristicasDhifeus
    {
        get { return _caracteristicasDhifeus; }
        set
        {
            _caracteristicasDhifeus = value;
            if (_caracteristicasDhifeus == null)
            {
                imagenHabilidad.color = disableColor;
            }
            else
            {
                imagenHabilidad.sprite = _caracteristicasDhifeus.imagenHabilidad;
                imagenHabilidad.color = colorNormal;
            }
        }
    }
    protected virtual void OnValidate()
    {
        if (imagenHabilidad == null)
        {
            imagenHabilidad = GetComponent<Image>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
