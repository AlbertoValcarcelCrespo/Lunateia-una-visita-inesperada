using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EstadoEnemigo
{
    Patrullar,
    Perseguir,
    Atacar
}

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

    private EstadoEnemigo estadoActual;
    public Transform[] waypoints;
    private int waypointActual = 0;


    private void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<InputEnemigo>();
        atacante = GetComponent<Atacante>();

        CambiarEstado(EstadoEnemigo.Patrullar);

    }


    private void Update()
    {
        Comportamiento();
    }

    void Comportamiento()
    {
        horizontal = input.horizontal;
        vertical = input.vertical;
        if (vertical != 0 || horizontal != 0)
        {
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);


        }
        switch (estadoActual)
        {
            case EstadoEnemigo.Patrullar:
                
                Patrullar();
                break;
            case EstadoEnemigo.Perseguir:
                Perseguir();
                break;
            case EstadoEnemigo.Atacar:
                Atacar();
                break;
        }
    }


    void Patrullar()
    {


        Transform destino = waypoints[waypointActual];
        MoverHacia(destino.position);

        if (Vector3.Distance(transform.position, destino.position) < 0.5f)
        {
            waypointActual = (waypointActual + 1) % waypoints.Length; 
            MoverHacia(destino.position);
        }



        if (input.distancia < distanciaDeteccion)
        {
            CambiarEstado(EstadoEnemigo.Perseguir);
        }
        animator.SetBool("Caminando", true);
        animator.SetBool("Atacando", false);
    }


    private void MoverHacia(Vector3 posicion)
    {
        // Calcula la dirección y mueve al enemigo
        Vector3 direccion = (posicion - transform.position).normalized;
        transform.position += direccion * atributos.velocidad * Time.deltaTime;

        animator.SetBool("Caminando", true);
        animator.SetBool("Atacando", false);
    }


    void Perseguir()
    {


        if (input.distancia < distanciaDeteccion)
        {

            MoverHaciaJugador();
        }
        if (input.distancia <= distanciaAtaque)
        {

            CambiarEstado(EstadoEnemigo.Atacar);

        }
        else if (input.distancia > distanciaDeteccion)
        {

            CambiarEstado(EstadoEnemigo.Patrullar);

        }
        animator.SetBool("Caminando", true); 
        animator.SetBool("Atacando", false);
    }

    void Atacar()
    {


        if (input.distancia > distanciaAtaque)
        {
            // Ejecutar animación de ataque y lógica de daño
            CambiarEstado(EstadoEnemigo.Perseguir);
            return;
        }


        EsqueletoAtacar();
        animator.SetBool("Caminando", false);
        animator.SetBool("Atacando", true);

    }

    void CambiarEstado(EstadoEnemigo nuevoEstado)
    {
        estadoActual = nuevoEstado;
    }



    void EsqueletoAtacar()
    {
        atacante.Atacar(direccionAtaque, atributos.ataque) ;
    }

    private void MoverHaciaJugador()
    {
        Vector3 direccion = (input.jugador.position - transform.position).normalized;

        transform.position += direccion * atributos.velocidad * Time.deltaTime;
    }

    public void Morir()
    {
        muerto = true;
        animator.SetBool("Muerto", true);
    }


}
