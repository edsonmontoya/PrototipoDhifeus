using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaFuego : MonoBehaviour
{
    public int velX = 5;
    int velY = 0;
    public SpriteRenderer sprBalaFuego;


    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(velX * Time.deltaTime, velY);
        Destroy(gameObject, 2f);
    }
    public void CambiarDireccionBala(int GirandoObjeto)
    {
        velX = GirandoObjeto;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigos"))
        {
            Destroy(gameObject);
        }
    }
}