using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    public float Jfolse = 30;

    private const int ANIMATION_IDLE = 0;//quieto
    private const int ANIMATION_RUN = 1; //correr
    private const int ANIMATION_JUMP = 2; //saltar
    private const int ANIMATION_DEAD = 3; //morir
    //private const int ANIMATION_THROW = 4;


    private Rigidbody2D rb; //Posicion
    private Animator animator; //Movimiento
    private SpriteRenderer sr;

    private bool choqueTumba = false;
    private bool choqueZombie = false;
    private bool muertoNinja = false;

    void Start()
    {
        //Aumentar disminuir la velocidad del objeto
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", ANIMATION_IDLE);

        if (Input.GetKey(KeyCode.RightArrow) && muertoNinja != true)
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
            animator.SetInteger("Estado", ANIMATION_RUN);
            sr.flipX = false;

        }
        if (Input.GetKey(KeyCode.LeftArrow) && muertoNinja != true)
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            animator.SetInteger("Estado", ANIMATION_RUN);
            sr.flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.Space) && muertoNinja != true)
        {
            rb.AddForce(new Vector2(0, Jfolse), ForceMode2D.Impulse);
            animator.SetInteger("Estado", ANIMATION_JUMP);
        }
        if (choqueZombie)
        {
            animator.SetInteger("Estado", ANIMATION_DEAD);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("ObsSombie"))
        {
            Debug.Log("Choca con la tumba y muere");
            choqueZombie = true;
            muertoNinja = true;
        }
    } 
}
