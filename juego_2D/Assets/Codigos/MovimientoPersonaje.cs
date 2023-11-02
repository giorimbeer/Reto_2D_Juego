using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;

    public Vector3 posicionInicio { get; set; }
    public Vector3 escalaInicio { get; set; }

    private bool enElsuelo = false;
    private Rigidbody2D cuerpoRigido;
    private Animator animaciones;

    private bool activar = false;
    private Transform trampPinchos;
    private Vector2 starPosition;

    void Awake()
    {
        escalaInicio = transform.localScale;
        posicionInicio = transform.position;
        cuerpoRigido = GetComponent<Rigidbody2D>();   
        animaciones = GetComponent<Animator>();
    }

    private void Start()
    {
        if (GameObject.Find("trampaCaida"))
        {
            trampPinchos = GameObject.Find("trampaCaida").transform;
            starPosition = trampPinchos.position;
        }
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        cuerpoRigido.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, cuerpoRigido.velocity.y);

        if (Input.GetButtonDown("Jump") && enElsuelo)
        {
            cuerpoRigido.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento,0);
            cuerpoRigido.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            enElsuelo = false;
        }

        if (movimientoHorizontal > 0)
            transform.localScale = new Vector3(escalaInicio.x, escalaInicio.y, escalaInicio.z);
        else if (movimientoHorizontal < 0)
            transform.localScale = new Vector3(-escalaInicio.x, escalaInicio.y, escalaInicio.z);

        animaciones.SetInteger("Salto", (int) cuerpoRigido.velocity.y);
        animaciones.SetBool("Piso", enElsuelo);

        if(enElsuelo)
            animaciones.SetFloat("MovimientoHorizontal", Mathf.Abs(movimientoHorizontal));





        if(trampPinchos != null)
        {
            if (activar)
            {
                trampPinchos.position = new Vector2(trampPinchos.position.x, trampPinchos.position.y - 3 * Time.deltaTime);
            }
            else trampPinchos.position = starPosition;

            if (trampPinchos.position.y < -82)
            {
                activar = false;
    }
    }
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        enElsuelo = collision.gameObject.CompareTag("Suelo");

        if (collision.gameObject.CompareTag("Morir"))
            Reinicio();
    }


    void Reinicio()
    {
        cuerpoRigido.velocity = Vector2.zero;
        cuerpoRigido.angularVelocity = 0;
        cuerpoRigido.bodyType = RigidbodyType2D.Static;
        transform.position = posicionInicio;
        cuerpoRigido.bodyType = RigidbodyType2D.Dynamic;

        activar = false;
    }

    
   private void OnTriggerExit2D(Collider2D collision)
   {
        if (collision.gameObject.CompareTag("Active"))
        {
            activar = true;
        }
    }
}

