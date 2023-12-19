using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class Objeto : Interactivo
{

    public Item item;
    private SpriteRenderer spriteRenderer;
   // private BoxCollider2D boxCollider;
    public int cantidad = 1;

    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.name = item.nombre;
        spriteRenderer.sprite = item.sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        miColisionador = GetComponent<BoxCollider2D>();
        // boxCollider = GetComponent<BoxCollider2D>();
        player = GameManager.instance.jugador.GetComponent<PlayerController>();
        spriteRenderer.sortingLayerID = 11;
        //spriteRenderer.sortingLayerID = "Drop";

        miColisionador.isTrigger = true;
        miColisionador.size = new Vector2(1, 1);
        gameObject.layer = 11;

    }


    public override void Interaccion()
    {
        Debug.Log("Interactuando con " + item.name);
        if (Inventario.instance.AgregarObjeto(item, cantidad))
        {
            Destroy(gameObject);
        }

    }

}
