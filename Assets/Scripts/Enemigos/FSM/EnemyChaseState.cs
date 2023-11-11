using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : BaseState
{

    public EnemyChaseState(MaquinaDeEstados maquinaDeEstados, Animator animator, InputEnemigo input, Atacante atacante, float distanciaDeteccion, float distanciaAtaque)
        : base(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque)
    {
       // this.EnterState();
    }

    public override void EnterState()
    {
       animator.SetBool("Caminando", true);
    //    maquinaDeEstados.TransitionToState(new EnemyChaseState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));

        
      //  transform.position += (Vector3)input.direccionHaciaJugador * maquinaDeEstados.atributos.velocidad * Time.deltaTime;

    }

    public override void UpdateState()
    {
        if (input.distancia < distanciaAtaque)
        {
            this.ExitState();
            maquinaDeEstados.TransitionToState(new EnemyAttackState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));
            
        }
        else if (input.distancia > distanciaDeteccion)
        {
            this.ExitState();
            maquinaDeEstados.TransitionToState(new EnemyPatrolState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));
        }
        else
        {
            maquinaDeEstados.MoverHaciaJugador();
        }
    }

    public override void ExitState()
    {
        animator.SetBool("Caminando", false);
        //this.UpdateState();
    }
}