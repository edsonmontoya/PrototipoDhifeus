using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaccionCaja : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float speed;
    public ControlJugador controlJugador;
    public GameObject Puerta;
    public SpriteRenderer puertaCerrada;
    public SpriteRenderer puertaAbierta;
    public BoxCollider2D colliderPuerta;


    public void Update()
    {
        if (controlJugador.botonVerde && controlJugador.botonRojo == true)
        {
            puertaCerrada.sprite = puertaAbierta.sprite;
            colliderPuerta.enabled = false;
        }
    }
    IEnumerator CajaIZQ()
    {
        yield return new WaitForSeconds(1f);
        speed = 0;
    }
    public void FixedUpdate()
    {
        rbody.velocity = Vector2.right * speed;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("BalaAire")&& controlJugador.sprRenderer.flipX == true)
        {
            speed = -2;
            StartCoroutine("CajaIZQ");
        }
        if (collision.CompareTag("BalaAire") && controlJugador.sprRenderer.flipX == false)
        {
            speed = 2;
            StartCoroutine("CajaIZQ");
        }
        if (collision.CompareTag("BotonVerde"))
        {
            controlJugador.botonVerde = true;
        }
        if (collision.CompareTag("BotonRojo"))
        {
            controlJugador.botonRojo = true;

        }

    }
}
