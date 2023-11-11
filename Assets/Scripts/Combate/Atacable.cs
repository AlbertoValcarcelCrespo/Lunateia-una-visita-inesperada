using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacable : MonoBehaviour
{
    private Salud miSalud;
    private Rigidbody2D miRigidBody;

    private void Start()
    {
        miSalud = GetComponent<Salud>();
        miRigidBody = GetComponent<Rigidbody2D>();
    }


    public void RecibirAtaque()
    {
        miSalud.SaludActual -= 1;
    }

    public void RecibirAtaque(int dano, Vector2 direccionDeAtaque)
    {
        //miSalud.saludBase -= dano;
        miSalud.modificarSaludActual(-dano);
        miRigidBody.AddForce(direccionDeAtaque * dano * 100);
    }



}
