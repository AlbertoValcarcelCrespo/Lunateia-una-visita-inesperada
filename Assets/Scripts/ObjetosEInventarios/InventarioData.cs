using System;
using System.Collections.Generic;

[Serializable]
public class InventarioData
{
    public List<ItemData> items;

    public InventarioData()
    {
        items = new List<ItemData>();
    }

    public void A�adirItem(ItemData itemData)
    {
        items.Add(itemData);
    }
}

[Serializable]
public class ItemData
{
    public string itemId;
    public int cantidad;
    public string tipoItem; 

}