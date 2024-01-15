using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
    public int saludBase;
    private int saludActual;
  //  public Transform barraSalud;
    public Image barraSalud;
    public UnityEvent OnMorir;

    public int ModificadorSalud;
    public int salud { get { return saludBase + ModificadorSalud; } }

    public int SaludActual
    {
        get
        {
            return saludActual;
        }
        set
        {
            if (value > 0 && value <= salud)
            {
                saludActual = value;
            }
            else if (value > salud)
            {
                saludActual = salud;
            }
            else
            {
                saludActual = 0;
                gameObject.layer = 10;
                if(OnMorir!= null)
                {
                    OnMorir.Invoke();
                }
               // Destroy(gameObject);
            }
        }
    }



    void Start()
    {
        SaludActual = salud;
        barraSalud = CanvaPers.insta.barraSalud;
        ReiniciarSalud();

    }


    public void modificarSaludActual(int cantidad)
    {
        SaludActual += cantidad;
        ActualizarBarraSalud();
    }

    private void DestruirGameObject()
    {
        Destroy(gameObject);
    }

    public void ActualizarBarraSalud()
    {
        // Vector3 escala = new Vector3((float)SaludActual / saludBase, 1, 1);
        // barraSalud.localScale = escala;
        if (barraSalud)
        {
            barraSalud.fillAmount = (float)SaludActual / salud;
        }
    }


    public void ModificarSaludBase(int cantidad)
    {
        saludBase += cantidad;
        ActualizarBarraSalud();
    }

    public void ReiniciarSalud()
    {
        SaludActual = saludBase;// salud; // Restablece la salud actual al máximo
                                //   SaludActual = salud;
        barraSalud.fillAmount = 1;
        //ActualizarBarraSalud(); // Actualiza la barra de salud visualmente
    }


}
