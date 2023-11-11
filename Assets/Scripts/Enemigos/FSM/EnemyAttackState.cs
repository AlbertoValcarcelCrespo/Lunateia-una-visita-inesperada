using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    private Vector2 direccionAtaque;
    private Atributos atributos;

    public EnemyAttackState(MaquinaDeEstados maquinaDeEstados, Animator animator, InputEnemigo input, Atacante atacante, float distanciaDeteccion, float distanciaAtaque)
        : base(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque)
    {
      //  this.EnterState();

    }

    public override void EnterState()
    {
      //  maquinaDeEstados.TransitionToState(new EnemyAttackState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));

     //   animator.SetBool("Caminando", false);
        animator.SetBool("Atacando", true);
       // direccionAtaque = input.direccionHaciaJugador;
       // atributos = maquinaDeEstados.Atributos();
       // atacante.Atacar(direccionAtaque, atributos.ataque);
        maquinaDeEstados.ComenzarAtaque();
    }

    public override void UpdateState()
    {
        if (input.distancia > distanciaAtaque)
        {
           this.ExitState(); 
            maquinaDeEstados.TransitionToState(new EnemyChaseState(maquinaDeEstados, animator, input, atacante, distanciaDeteccion, distanciaAtaque));

        }
    //    else
     //   {
    //        maquinaDeEstados.ComenzarAtaque();
    //    }
    }

    public override void ExitState()
    {
        animator.SetBool("Atacando", false);
       // animator.SetBool("Caminando", true);
    }
}