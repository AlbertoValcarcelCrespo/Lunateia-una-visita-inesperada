using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
    public int saludBase;
    private int saludActual;
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
        SaludActual = saludBase;
        barraSalud.fillAmount = 1;
    }


}
