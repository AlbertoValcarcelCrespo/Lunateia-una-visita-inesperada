using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : DecisionNode
{
    private DecisionNode trueNode;
    private DecisionNode falseNode;
    private Func<bool> testCondition;

    public Decision(Func<bool> test, DecisionNode trueNode, DecisionNode falseNode)
    {
        this.testCondition = test;
        this.trueNode = trueNode;
        this.falseNode = falseNode;
    }

    public override DecisionNode MakeDecision()
    {
        return testCondition() ? trueNode : falseNode;
    }
}