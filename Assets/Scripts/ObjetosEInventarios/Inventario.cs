using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public bool inventarioLleno;
    public static Inventario instance;
    private Casilla[] casillas;
    private List<Item> objetos = new List<Item>();
    private int casillaVacia = 0;

    private void Awake()
    {
        instance = this;
        casillas = GetComponentsInChildren<Casilla>();

    }


    void DeterminarSiguienteCasillaVacia()
    {
        casillaVacia = 0;
        foreach ( Casilla casilla in casillas )
        {
            if (casilla.itemAlmacenado)
            {
                casillaVacia++;
            }
            else
            {
                break;
            }
        }

        if( casillaVacia >= casillas.Length)
        {
            inventarioLleno = true;
        }
    }

    public bool AgregarObjeto(Item item, int cantidad)
    {
        DeterminarSiguienteCasillaVacia();
        if ((item.apilable && !objetos.Contains(item) && !inventarioLleno) || (!item.apilable && !inventarioLleno))
        {

            Casilla casillaAñadir = casillas[casillaVacia];
            objetos.Add(item);
            casillaAñadir.AñadirObjeto(item, cantidad);
            return true;

        }
        else if (item.apilable == true && objetos.Contains(item))
        {
            for(int i = 0; i < casillas.Length; i++)
            {
                if( item == casillas[i].itemAlmacenado)
                {
                    casillas[i].cantidadStock += cantidad;
                    break;
                }
            }
            return true;
        }
        else
        {
            Debug.Log("Inventario Lleno");
            return false;
        }
    }


    public void RemoverObjeto(Item item)
    {
      //  Debug.Log("ELementos"+ objetos);
        objetos.Remove(item);
    }


}
