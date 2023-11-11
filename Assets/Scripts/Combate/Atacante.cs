using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacante : MonoBehaviour
{
    public Vector2 hitBox = new Vector2(1, 1);
    public float desfase = 1f;
    private Vector2 vectorDesfaseAtaque;
    private Vector2 puntoA, puntoB;
    public LayerMask layerAtaque;
    private Collider2D[] ataqueColliders = new Collider2D[12];
    public ContactFilter2D filtroDeAtaque;

    private void Start()
    {
        filtroDeAtaque.layerMask = layerAtaque;
        filtroDeAtaque.useLayerMask = true;
    }

    public void Atacar(Vector2 direccionAtaque, int dano)
    {
        CrearHitBox(direccionAtaque);
        GameObject objetoAtacado;
        int elementosAtacados = Physics2D.OverlapArea(puntoA, puntoB, filtroDeAtaque, ataqueColliders);
        Debug.Log("el num es:" + elementosAtacados);
        for(int i = 0;i < elementosAtacados;i++)
        {
            objetoAtacado = ataqueColliders[i].gameObject;
            if (objetoAtacado.GetComponent<Atacable>())
            {
                //objetoAtacado.GetComponent<Atacable>().RecibirAtaque();
                objetoAtacado.GetComponent<Atacable>().RecibirAtaque(dano, direccionAtaque);
            }
            //ataqueColliders[i].gameObject.GetComponent<Atacable>().RecibirAtaque(); 

        }
        //Debug.DrawLine(transform.position, (Vector2)transform.position + vectorDesfaseAtaque, Color.yellow); 
        //Debug.DrawLine(puntoA, puntoB, Color.red);
    }

    public void CrearHitBox(Vector2 direccionAtaque)
    {
        Vector2 escala = transform.lossyScale;
        Vector2 hitBoxEscalado = Vector2.Scale(hitBox, escala);
        vectorDesfaseAtaque = Vector2.Scale(direccionAtaque.normalized * desfase, escala);

        puntoA = (Vector2)transform.position + vectorDesfaseAtaque - hitBoxEscalado * 0.5f;
        puntoB = puntoA + hitBoxEscalado;
    }


}
