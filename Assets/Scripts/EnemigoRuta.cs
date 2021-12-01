using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRuta : MonoBehaviour
{
    public int hitPoints;
    public float speed;
    public float speedUp;
    public Rigidbody2D rbody;
    public SpriteRenderer sprRenderer;
    public float offset;
    public float raycastLenght;
    public LayerMask groundLayer;
    public ControlJugador controlJugador;
    public int SaludEnemigo;


    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2.5f);
        speedUp = 0;
        rbody.position = new Vector2(rbody.position.x, rbody.position.y - 0.005f);
    }
    IEnumerator Retroceso()
    {
        speed = 3;
        yield return new WaitForSeconds(1f);
        speed = -3;
        CheckForLimits();
    }
    IEnumerator Retroceso2()
    {
        speed = -3;
        yield return new WaitForSeconds(1f);
        speed = 3;
        CheckForLimits();
    }
    void Update()
    {
        CheckForLimits();
        if (speedUp == 3f)
        {
            rbody.position = new Vector2(rbody.position.x, rbody.position.y + 0.005f);
            StartCoroutine("Esperar");
        }
        if(SaludEnemigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        rbody.velocity = Vector2.right * speed;
    }
    void CheckForLimits()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right * offset, Vector2.down, raycastLenght, groundLayer);
        if (hit.collider == null)
        {
            offset *= -1;
            speed *= -1;
            sprRenderer.flipX = !sprRenderer.flipX;
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaFuego"))
        {
            SaludEnemigo = SaludEnemigo - 20;
        }
        if (collision.CompareTag("BalaPsiquica"))
        {
            raycastLenght = 20;
            rbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<EnemigoRuta>().speedUp = 3f;
            
        }
        if (collision.CompareTag("Piso"))
        {
            raycastLenght = 2f;
            rbody.constraints = RigidbodyConstraints2D.None;
        }
        if (collision.CompareTag("BalaDoble"))
        {
            offset *= -1;
            speed *= -1;
            sprRenderer.flipX = !sprRenderer.flipX;
        }
        if (collision.CompareTag("BalaAire")&& this.speed == -3)
        {
            speed = 3;
            StartCoroutine("Retroceso");
           
        }
        else if (collision.CompareTag("BalaAire") && this.speed == 3)
        {
            speed = -3;
            StartCoroutine("Retroceso2");

        }
    }
}
