using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : BaseState
{
    private float horizontal;
    private float vertical;
    private ControladorNavMesh controladorNavMesh;
    public Transform[] WayPoints;
    private int siguienteWayPoint;
    public NavMeshAgent agent;


    public EnemyPatrolState(MaquinaDeEstados maquinaDeEstados, Animator animator, InputEnemigo input, Atacante atacante, float distanciaDeteccion, float distanciaAtaque)
        : base(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque)
    {
        horizontal = input.horizontal;
        vertical = input.vertical;
        this.EnterState();
        agent = GetComponent<NavMeshAgent>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        agent.destination += WayPoints[siguienteWayPoint].position;
        agent.destination = WayPoints[siguienteWayPoint].position;
        agent.SetDestination(WayPoints[siguienteWayPoint].position);

    }

    public override void EnterState()
    {
         animator.SetBool("Caminando", true);
        agent.destination += WayPoints[siguienteWayPoint].position;
        agent.destination = WayPoints[siguienteWayPoint].position;
        agent.SetDestination(WayPoints[siguienteWayPoint].position);
        //siguienteWayPoint = 0;
        siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
        ActualizarWayPointDestino();

        // animator.SetFloat("X", horizontal);
        // animator.SetFloat("Y", vertical);
    }

    public override void UpdateState()
    {
        siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
        ActualizarWayPointDestino();
        //  animator.SetFloat("X", horizontal);
        //  animator.SetFloat("Y", vertical);

        //  controladorNavMesh.ActualizarWayPointDestino();
        // controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
     //   Vector2 destino = WayPoints[siguienteWayPoint].position;
     //   Vector2 nuevaPosicion = Vector2.MoveTowards(transform.position, destino, 5f * Time.deltaTime);
     //   transform.position = nuevaPosicion;
        agent.destination += (Vector3)WayPoints[siguienteWayPoint].position * Time.deltaTime;
        agent.destination += WayPoints[siguienteWayPoint].position;
        agent.SetDestination(WayPoints[siguienteWayPoint].position);

        if (input.distancia < distanciaAtaque)
        {
            this.ExitState();
            maquinaDeEstados.TransitionToState(new EnemyAttackState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));
        }
        else if (input.distancia > distanciaDeteccion)
        {
            this.ExitState();
            maquinaDeEstados.MoverHaciaJugador();
            maquinaDeEstados.TransitionToState(new EnemyChaseState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));
        }
        else if (controladorNavMesh.HemosLlegado())
        {
          //  siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            ActualizarWayPointDestino();
        }
        else
        {
            maquinaDeEstados.MoverHaciaJugador();
           // controladorNavMesh.perseguirObjectivo = maquinaDeEstados.MoverHaciaJugador();
        }
    }

    public override void ExitState()
    {
        animator.SetBool("Caminando", false);
    }


    void OnEnable()
    {
      //  maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguienteWayPoint].position);
        agent.destination += (Vector3)WayPoints[siguienteWayPoint].position * Time.deltaTime;

        transform.position += (Vector3)WayPoints[siguienteWayPoint].position  * Time.deltaTime;
    }

/*
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == WayPoints[siguienteWayPoint])
        {
            Debug.Log("Llegó al WayPoint: " + siguienteWayPoint);
            llegoAlWayPoint = true;
        }
    }
*/


}