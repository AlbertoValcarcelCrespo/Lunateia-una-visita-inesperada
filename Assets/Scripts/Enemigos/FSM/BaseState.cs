using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
