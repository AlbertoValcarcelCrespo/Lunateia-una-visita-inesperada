using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Casilla : MonoBehaviour
{

    public int cantidadStock;
    public Item itemAlmacenado;
    private Image image;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(itemAlmacenado == null)
        {
            image.enabled = false;
        }
    }

    public void AñadirObjeto(Item item, int cantidad)
    {
        itemAlmacenado = item;
        image.enabled = true;
        image.sprite = item.sprite;
        cantidadStock = cantidad;
    }

    public virtual void EliminarObjeto()
    {
        Inventario.instance.RemoverObjeto(itemAlmacenado);
        ResetearCasilla();
    }



    protected virtual void UsarObjetoEnCasilla()
    {
        if (itemAlmacenado)
        {
            if (itemAlmacenado.UsarItem())
            {
                ReducirStock(1);
                //cantidadStock--;
            }
        }
    }
    void ReducirStock(int cantidad)
    {
        cantidadStock -= cantidad;
        if (cantidadStock <= 0)
        {
            EliminarObjeto();
        }
    }

    protected void ResetearCasilla()
    {
        image.sprite = null;
        cantidadStock = 0;
        image.enabled = false;
        itemAlmacenado = null;
    }



    public void OnMouseDown()
    {

       Debug.Log("Haciendo Click 55555");
        UsarObjetoEnCasilla();


    }



}
