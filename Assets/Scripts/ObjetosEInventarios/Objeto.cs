using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Objeto : Interactivo
{

    public Item item;
    private SpriteRenderer spriteRenderer;
    public int cantidad = 1;
    public string itemId; // Identificador único para el objeto
    public bool recogido = false;
    public GameObject p;




    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        miColisionador = GetComponent<BoxCollider2D>();

        p = GameObject.FindGameObjectWithTag("Player");
        player = p.GetComponent<PlayerController>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingLayerName = "Drop";

        gameObject.name = item.nombre;
        spriteRenderer.sprite = item.sprite;
        miColisionador.isTrigger = true;
        miColisionador.size = new Vector2(1, 1);
        gameObject.layer = 11;

        CheckItemState();

    }


    private void CheckItemState()
    {
        // Comprueba si el objeto ya ha sido recogido
        if (PlayerPrefs.GetInt(item.id, 0) == 1)
        {
            gameObject.SetActive(false); // Desactiva el objeto si ya fue recogido
        }
    }

    public override void Interaccion()
    {
        Debug.Log("Interactuando con " + item.name);
        if (Inventario.instance.AgregarObjeto(item, cantidad))
        {
            // Marcar como recogido
            PlayerPrefs.SetInt(item.id, 1);
            PlayerPrefs.Save();

            // Desactivar el objeto después de ser recogido
            if (recogido = true){
                 gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }

    }




}