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

        //CambiarEstado(new PatrullarEstado(this));
        CambiarEstado(EstadoEnemigo.Patrullar);

    }


    private void Update()
    {
      //  transform.position += (Vector3)input.direccionHaciaJugador * atributos.velocidad * Time.deltaTime;
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
                //  MoverHacia(destino.position);
                
                Patrullar();
                break;
            case EstadoEnemigo.Perseguir:
             //   MoverHaciaJugador();
                Perseguir();
                break;
            case EstadoEnemigo.Atacar:
            //    EsqueletoAtacar();
                Atacar();
                break;
        }


        /* horizontal = input.horizontal;
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
        }*/
    }


    void Patrullar()
    {


        Transform destino = waypoints[waypointActual];
        MoverHacia(destino.position);

        if (Vector3.Distance(transform.position, destino.position) < 0.5f)
        {
            waypointActual = (waypointActual + 1) % waypoints.Length; // Asegúrate de que el índice siempre esté dentro del rango
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

        // Actualiza la animación si es necesario
        animator.SetBool("Caminando", true);
        animator.SetBool("Atacando", false);
    }


    void Perseguir()
    {
        //  MoverHaciaJugador();
        // Lógica para perseguir

        if (input.distancia < distanciaDeteccion)
        {

            MoverHaciaJugador();
          //  CambiarEstado(EstadoEnemigo.Perseguir);
          //  animator.SetBool("Caminando", true); // O usaR un parámetro diferente como una animación de carrera
          //  animator.SetBool("Atacando", false);
        }
        if (input.distancia <= distanciaAtaque)
        {

            CambiarEstado(EstadoEnemigo.Atacar);
           // animator.SetBool("Caminando", false); // O usaR un parámetro diferente como una animación de carrera
          //  animator.SetBool("Atacando", true);
        }
        else if (input.distancia > distanciaDeteccion)
        {
            //  MoverHaciaJugador();
         //   animator.SetBool("Caminando", true); // O usaR un parámetro diferente como una animación de carrera
         //   animator.SetBool("Atacando", false);
            CambiarEstado(EstadoEnemigo.Patrullar);
            //  MoverHaciaJugador();
          //  animator.SetBool("Caminando", true); // O usaR un parámetro diferente como una animación de carrera
        //    animator.SetBool("Atacando", false);
        }
        animator.SetBool("Caminando", true); // O usaR un parámetro diferente como una animación de carrera
        animator.SetBool("Atacando", false);
    }

    void Atacar()
    {


        if (input.distancia > distanciaAtaque)
        {
            // Ejecutar animación de ataque y lógica de daño
            CambiarEstado(EstadoEnemigo.Perseguir);
            return;
            // Posiblemente llamar a un método que maneje el ataque
        }
        //  else
        //  {
        //     animator.SetBool("Atacando", false);
        //    CambiarEstado(EstadoEnemigo.Perseguir);

        EsqueletoAtacar();
        animator.SetBool("Caminando", false);
        animator.SetBool("Atacando", true);
        //  animator.SetBool("Caminando", false);
        // animator.SetBool("Atacando", true);
    }

    void CambiarEstado(EstadoEnemigo nuevoEstado)
    {
        estadoActual = nuevoEstado;
        // Puedes agregar aquí lógica adicional para cuando cambia el estado.
    }



    void EsqueletoAtacar()
    {
        atacante.Atacar(direccionAtaque, atributos.ataque) ;
     //   atacando = false;
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
