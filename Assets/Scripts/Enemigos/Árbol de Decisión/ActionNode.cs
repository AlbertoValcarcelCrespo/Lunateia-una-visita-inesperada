using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : DecisionNode
{
    private Action action;

    public ActionNode(Action action)
    {
        this.action = action;
    }

    public override DecisionNode MakeDecision()
    {
        action();
        return this; // Mantener el mismo nodo, ya que es un nodo de acción
    }
}