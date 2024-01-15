using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaludEnemigo : MonoBehaviour
{
    public int saludBase;
    private int saludActual;
    //  public Transform barraSalud;
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
                if (OnMorir != null)
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


        //barraSalud = CanvaPers.insta.barraSalud;
     //   ReiniciarSalud();

    }


    public void modificarSaludActual(int cantidad)
    {
        SaludActual += cantidad;
    }

    private void DestruirGameObject()
    {
        Destroy(gameObject);
    }



    public void ModificarSaludBase(int cantidad)
    {
        saludBase += cantidad;
    }




}