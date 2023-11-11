using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : Enemigo
{
    private float horizontal;
    private float vertical;

    private InputEnemigo input;
    private Atacante atacante;
    private bool muerto;
    private bool atacando;
    private bool enCombate;
    private Animator animator;
    private Vector2 direccionAtaque;

    [SerializeField] private float distanciaDeteccion;
    [SerializeField] private float distanciaAtaque;

    private void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<InputEnemigo>();
        atacante = GetComponent<Atacante>();
    }


    private void Update()
    {
        transform.position += (Vector3)input.direccionHaciaJugador * atributos.velocidad * Time.deltaTime;
        Comportamiento();
    }

    void Comportamiento()
    {
        horizontal = input.horizontal;
        vertical = input.vertical;


 


        if (!muerto){
            if (vertical != 0 || horizontal != 0)
            {
                animator.SetFloat("X", horizontal);
                animator.SetFloat("Y", vertical);


            }
            if (!atacando && input.distancia < distanciaAtaque){
                direccionAtaque = input.direccionHaciaJugador;
                atacando = true;
                enCombate = true;
                animator.SetBool("Caminando", false);
               // animator.SetTrigger("Atacar");
                animator.SetBool("Atacando", true);
                EsqueletoAtacar();
         }
         else if ( ( input.distancia > distanciaDeteccion))
            {
                atacando = false;
                animator.SetBool("Atacando", false);
                animator.SetBool("Caminando", true);

                MoverHaciaJugador();
            }
       }
    }


    void EsqueletoAtacar()
    {
        atacante.Atacar(direccionAtaque, atributos.ataque) ;
        atacando = false;
    }

    private void MoverHaciaJugador()
    {
        transform.position += (Vector3)input.direccionHaciaJugador * atributos.velocidad * Time.deltaTime;
    }

    public void Morir()
    {
        muerto = true;
        animator.SetBool("Muerto", true);
    }


}
