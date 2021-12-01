using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float movementSpeed = 0f;
    public float currentSpeed;
    public SpriteRenderer sprRenderer;
    public float raycastLength;
    public LayerMask groundLayer;
    public Transform feet;
    public bool botonVerde;
    public bool botonRojo;
    public Animator anmtr;
    public OpcionesDhifeus opcionesDhifeus;
    public float salto;
    public bool puedeSaltar;
    public bool dobleSalto;
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, raycastLength, groundLayer);
        if (hit.collider)
        {
            salto = 3;
            dobleSalto = false;
            puedeSaltar = true;
        }
        else
        {
            anmtr.SetBool("IsIdle", false);
            puedeSaltar = false;
        }
        if (dobleSalto == true)
        {
            anmtr.SetBool("IsIdle", false);
            salto = 0;
        }

        // anmtr.SetBool("isIdle", true);
        Inputs();
        void Inputs()
        {
            currentSpeed = Input.GetAxis("Horizontal");

            if (currentSpeed != 0) 
                {
               
                    if (currentSpeed < 0)
                    {
                    anmtr.SetBool("IsIdle", false);
                        sprRenderer.flipX = true;
                    }
                    else
                    {
                    anmtr.SetBool("IsIdle", false);
                    sprRenderer.flipX = false;
                    }
                }
            else
            {
                anmtr.SetBool("IsIdle", true);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                anmtr.SetBool("IsIdle", false);
                ValoresSalto();
                //dobleSalto = true;
                puedeSaltar = false;
                if (Input.GetKeyDown(KeyCode.W) && puedeSaltar == false)
                {
                    anmtr.SetBool("IsIdle", false);
                    ValoresSalto();
                    dobleSalto = true;
                    puedeSaltar = false;
                }
            }
            
        }
    }
    public void ValoresSalto()
    {
        rbody.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        rbody.velocity = currentSpeed * Vector2.right * movementSpeed + rbody.velocity.y * Vector2.up;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal") && Input.GetKeyDown(KeyCode.Space))
        {
            opcionesDhifeus.habilidadesEncedido = true;
        }
    }


}

