using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
  /*  public Transform jugador;
    public float vertical { get { return direccionHaciaJugador.y; } }
    public float horizontal { get { return direccionHaciaJugador.x; } }
    public float distancia { get { return direccionHaciaJugador.magnitude; } }
    public Vector2 direccionHaciaJugador { get; private set; }
    
    BaseState currentState;

    [HideInInspector] public Idle idleState;
    [HideInInspector] public Correr correrState;
    [HideInInspector] public Atacar atacarState;
    [HideInInspector] public IEstadoHuesitos estadoActual;


    private void Awake()
    {
        idleState = new Idle(this);
        correrState = new Correr(this);
        atacarState = new Atacar(this);

        navMeshAgent = getComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Start()
    {
        direccionHaciaJugador = jugador.position - transform.position;
        estadoActual = idleState;

 //       currentState = GetInitialState();
 //       if (currentState != null)
 //           currentState.Enter();
    }

    void Update()
    {
        direccionHaciaJugador = jugador.position - transform.position;
        estadoActual.ActualizaEstado();


 //       if (currentState != null)
 //           currentState.UpdateLogic();
    }

    private void OnTriggerEnter (Collider other)
    {
        estadoActual.ActualizarEstado();
    }

//    void LateUpdate()
 //   {
  //      if (currentState != null)
 //           currentState.UpdatePhysics();
  //  }

  //  protected virtual BaseState GetInitialState()
  //  {
  //      return null;
 //   }

 //   public void ChangeState(BaseState newState)
 //   {
  //      currentState.Exit();

  //      currentState = newState;
 //       newState.Enter();
 //   }
  */
}