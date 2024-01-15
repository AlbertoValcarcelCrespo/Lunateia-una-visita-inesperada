using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

public class PatrolState : State
{
    public override void Enter() { /* Inicialización del estado de patrulla */ }
    public override void Execute() { /* Lógica de patrulla */ }
    public override void Exit() { /* Limpieza al salir del estado de patrulla */ }
}