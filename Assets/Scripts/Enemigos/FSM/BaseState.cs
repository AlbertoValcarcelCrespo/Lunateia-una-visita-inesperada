using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class BaseState
{
    public string name;

    protected StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }

}
    */
    public abstract class BaseState : MonoBehaviour
    {
        protected MaquinaDeEstados maquinaDeEstados;
        protected Animator animator;
        protected InputEnemigo input;
        protected Atacante atacante;
        protected float distanciaDeteccion;
        protected float distanciaAtaque;

        public BaseState(MaquinaDeEstados maquinaDeEstados, Animator animator, InputEnemigo input, Atacante atacante, float distanciaDeteccion, float distanciaAtaque)
        {
            this.maquinaDeEstados = maquinaDeEstados;
            this.animator = animator;
            this.input = input;
            this.atacante = atacante;
            this.distanciaDeteccion = distanciaDeteccion;
            this.distanciaAtaque = distanciaAtaque;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
    }
