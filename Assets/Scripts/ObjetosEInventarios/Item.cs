using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("ObjetosEscriptables/Items/ItemGenerico"))]
public class Item : ScriptableObject
{
    public string id;
    public Sprite sprite;
    public string nombre;
    public bool apilable;
    [TextArea(1, 3)]
    public string descripcion;
    public int cantidadStock;
    public bool estaEquipado;

    public virtual bool UsarItem()
    {
        Debug.Log("Utilizando" + nombre);
        return true;
    }

}