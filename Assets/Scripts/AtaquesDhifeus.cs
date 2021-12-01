using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesDhifeus : MonoBehaviour
{
    public ControlJugador Jugador;
    public GameObject disparoPsiquico;
    public BalaPsiquica balaPsiquica;
    public float psiquicRate;
    private float nextFire = 0.0f;
    public int velocidadX;
    public SpriteRenderer sprBalaPsiquica;
    public PersonajeDhifeus estadisticasPersonaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            if (Jugador.sprRenderer.flipX == true)
            {
                nextFire = Time.time + psiquicRate;
                balaPsiquica.CambiarDireccionBala(-velocidadX);
                sprBalaPsiquica.flipX = true;
                Psiquico();
            }
            else
            {
                sprBalaPsiquica.flipX = false;
               nextFire = Time.time + psiquicRate;
                balaPsiquica.CambiarDireccionBala(velocidadX);
                Psiquico();
            }
        }
    }
    void Psiquico()
    {
        Instantiate(disparoPsiquico, transform.position, Quaternion.identity);
        estadisticasPersonaje.Mana = estadisticasPersonaje.Mana - 1;
    }
}
