using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float Velocidad = 2;
    public float Salto = 3;
    Rigidbody2D rb;
    public bool SaltoMejorado= false;
    public float caida= 0.5f;
    public float Bajo = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator Animacion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   void FixedUpdate()
    {

        if (Input.GetKey("d")||(Input.GetKey("right")))
        {
            rb.velocity = new Vector2(Velocidad, rb.velocity.y);
            spriteRenderer.flipX = false;
            Animacion.SetBool("Correr", true);
        }
        else if (Input.GetKey("a") || (Input.GetKey("left")))
        {
            rb.velocity = new Vector2(-Velocidad, rb.velocity.y);
            spriteRenderer.flipX = true;
           Animacion.SetBool("Correr", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            Animacion.SetBool("Correr", false);
        }
        if (Input.GetKey("w")||(Input.GetKey("up"))&&(CheckGround.IsGrounded))
        {
            rb.velocity = new Vector2(rb.velocity.x, Salto);
        }
        if (CheckGround.IsGrounded==false)
        {
            Animacion.SetBool("Saltar", true);
            Animacion.SetBool("Correr", false);
        }
        if (CheckGround.IsGrounded==true)
        {
            Animacion.SetBool("Saltar", false);
            
        }
        if (SaltoMejorado)
        {
            if (rb.velocity.y<0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (caida) * Time.deltaTime;
            }
            if (rb.velocity.y>0 && !Input.GetKey("w"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (Bajo) * Time.deltaTime;
            }
        }
    }
}
