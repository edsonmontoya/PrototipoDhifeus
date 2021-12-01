using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviento : MonoBehaviour
{
    public float velocidad;
    public Rigidbody2D Personaje;
    public SpriteRenderer monaazul;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("Caminar", true);

            Personaje.velocity = new Vector2(velocidad, Personaje.velocity.y); // nuevo vector de moviento
            monaazul.flipX = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            anim.SetBool("Caminar", false);

            Personaje.velocity = new Vector2(0, Personaje.velocity.y); // nuevo vector de moviento
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            anim.SetBool("Caminar", true);

            Personaje.velocity = new Vector2(-velocidad, Personaje.velocity.y);
            monaazul.flipX = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))

        {

            anim.SetBool("Caminar", false);

            Personaje.velocity = new Vector2(0, Personaje.velocity.y);

        }







    }
}
