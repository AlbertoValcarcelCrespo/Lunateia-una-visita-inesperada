using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MaquinaDeEstados : Enemigo
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

    private BaseState currentState;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
        input = GetComponent<InputEnemigo>();
        atacante = GetComponent<Atacante>();
       

        // Inicializa el estado de patrulla como estado inicial
        currentState = new EnemyPatrolState(this, animator, input, atacante, distanciaDeteccion, distanciaAtaque);
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void TransitionToState(BaseState nextState)
    {
        currentState.ExitState();
        currentState = nextState;
        currentState.EnterState();
    }

    public void ComenzarAtaque()
    {
        MaquinaDeEstadosAtacar();
    }

    void MaquinaDeEstadosAtacar()
    {
        atacante.Atacar(direccionAtaque, atributos.ataque);
        atacando = false;
    }

    public void MoverHaciaJugador()
    {
        transform.position += (Vector3)input.direccionHaciaJugador * atributos.velocidad * Time.deltaTime;
    }

    public void Morir()
    {
        muerto = true;
        animator.SetBool("Muerto", true);
    }
    public Atributos Atributos()
    {
        return this.Atributos();
    }
}

