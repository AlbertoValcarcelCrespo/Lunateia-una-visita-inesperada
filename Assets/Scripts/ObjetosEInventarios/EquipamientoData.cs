using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipamientoData
{
    public List<ItemData> itemsEquipados;

    public EquipamientoData()
    {
        itemsEquipados = new List<ItemData>();
    }

    public void A�adirItemEquipado(ItemData itemData)
    {
        itemsEquipados.Add(itemData);
    }
}