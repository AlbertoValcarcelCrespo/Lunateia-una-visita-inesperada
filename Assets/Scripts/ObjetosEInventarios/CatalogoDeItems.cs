using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NuevoCatalogoDeItems", menuName = "Inventario/CatalogoDeItems")]
public class CatalogoDeItems : ScriptableObject
{
    public List<Item> todosLosItems;

    public Item GetItemPorId(string id)
    {
        foreach (Item item in todosLosItems)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null; // Retorna null si no se encuentra el ítem
    }
}