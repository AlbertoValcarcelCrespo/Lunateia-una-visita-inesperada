using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Inventario : MonoBehaviour
{

    public bool inventarioLleno;
    public static Inventario instance;
    private Casilla[] casillas;
    public List<Item> objetos = new List<Item>();
    private int casillaVacia = 0;
    public CatalogoDeItems catalogoDeItems;

    private GestorMisiones gestorMisiones;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            casillas = GetComponentsInChildren<Casilla>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gestorMisiones = FindObjectOfType<GestorMisiones>();
    }

    public void RecolectarItem(Item item)
    {
        // Actualiza las misiones de recolección.
        gestorMisiones.RecolectarItem(item);
    }


    private void ActualizarUIInventario()
    {
        // Asumiendo que tienes un método que devuelve todas las casillas de UI del inventario
        Casilla[] casillasUI = GetComponentsInChildren<Casilla>(true);

        // Desactiva todas las casillas primero
        foreach (var casilla in casillasUI)
        {
            casilla.ResetearCasilla();
        }

        // Activa las casillas que tienen ítems y actualiza la información
        for (int i = 0; i < objetos.Count; i++)
        {
            casillasUI[i].AñadirObjeto(objetos[i], objetos[i].cantidadStock);
        }
    }


    void DeterminarSiguienteCasillaVacia()
    {
        casillaVacia = 0;
        foreach (Casilla casilla in casillas)
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

        if (casillaVacia >= casillas.Length)
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
            RecolectarItem(item);
            return true;

        }
        else if (item.apilable == true && objetos.Contains(item))
        {
            for (int i = 0; i < casillas.Length; i++)
            {
                if (item == casillas[i].itemAlmacenado)
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


    public void GuardarInventario()
    {
        InventarioData data = new InventarioData();
        foreach (Item item in objetos)
        {
            if (!item.estaEquipado) // Solo guarda ítems que no están equipados
            {
                ItemData itemData = new ItemData
                {
                    itemId = item.id,
                    cantidad = item.cantidadStock
                };
                data.AñadirItem(itemData);
            }
        }

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventario.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public void CargarInventario()
    {
        string path = Application.persistentDataPath + "/inventario.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InventarioData data = formatter.Deserialize(stream) as InventarioData;
            stream.Close();

            objetos.Clear();
            foreach (var itemData in data.items)
            {
                Item item = EncontrarOCrearItem(itemData);
                if (item != null)
                {
                    // Debug.Log("Item encontrado2" + itemData.itemId);

                    item.cantidadStock = itemData.cantidad;
                    item.estaEquipado = false;
                    objetos.Add(item);
                }
            }

            ActualizarUIInventario();
        }
        else
        {
            Debug.LogError("Archivo de inventario no encontrado");
        }
    }

    private Item EncontrarOCrearItem(ItemData itemData)
    {
        Item itemBase = catalogoDeItems.GetItemPorId(itemData.itemId);
        if (itemBase != null)
        {
            Item newItem = Instantiate(itemBase); // Crea una nueva instancia
            CopyProperties(itemBase, newItem); // Copia las propiedades
            newItem.cantidadStock = itemData.cantidad;
            return newItem;
        }

        Debug.LogWarning("Ítem no encontrado con ID: " + itemData.itemId);
        return null;
    }

    private void CopyProperties(Item source, Item destination)
    {
        // Copia las propiedades base
        destination.id = source.id;
        destination.nombre = source.nombre;
        destination.sprite = source.sprite;
        destination.descripcion = source.descripcion;
        destination.cantidadStock = source.cantidadStock;
        // Si tienes propiedades específicas en subclases, tendrías que manejarlas aquí también

        // Ejemplo para 'Equipamiento', que es una subclase de 'Item'
        if (source is Equipamiento sourceEquipamiento && destination is Equipamiento destinationEquipamiento)
        {
            // Copiar las propiedades específicas de Equipamiento
            destinationEquipamiento.salud = sourceEquipamiento.salud;
            destinationEquipamiento.ataque = sourceEquipamiento.ataque;
            destinationEquipamiento.velocidad = sourceEquipamiento.velocidad;
            destinationEquipamiento.tipoDeEquipamiento = sourceEquipamiento.tipoDeEquipamiento;
        }

        // Continúa con otras subclases según sea necesario
    }



    public void ReiniciarInventario()
    {
        objetos.Clear(); // Limpia la lista de objetos
        foreach (Casilla casilla in casillas)
        {
            casilla.ResetearCasilla(); //  Resetear la casilla de inventario
        }
        ActualizarUIInventario(); // Actualiza la UI del inventario
    }

}
