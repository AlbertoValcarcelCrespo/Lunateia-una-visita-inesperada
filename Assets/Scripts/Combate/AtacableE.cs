using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AtacableE : MonoBehaviour
{
    private SaludEnemigo saludE;

    private Rigidbody2D miRigidBody;

    private void Start()
    {
        saludE = GetComponent<SaludEnemigo>();
        miRigidBody = GetComponent<Rigidbody2D>();
    }


    public void RecibirAtaque()
    {
        saludE.SaludActual -= 1;

    }

    public void RecibirAtaque(int dano, Vector2 direccionDeAtaque)
    {
        saludE.modificarSaludActual(-dano);

        miRigidBody.AddForce(direccionDeAtaque * dano * 100);
    }



}

