using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{

    [HideInInspector] public float ejeX {get; private set;}
    [HideInInspector] public float ejeY {get; private set;}
    [HideInInspector] public bool atacar  {get; private set;}
    [HideInInspector] public bool habilidad1 {get; private set;}
    [HideInInspector] public bool habilidad2 {get; private set;}
    [HideInInspector] public bool habilidad3  {get; private set;}
    [HideInInspector] public bool saltar  {get; private set;}
    [HideInInspector] public bool interactuar {get; private set;}
    [HideInInspector] public bool inventario {get; private set; }
    public Vector2 direccionMirada = new Vector2( 0, -1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ATQ, HAB, ACTION, INVENTARIO
        atacar = Input.GetButtonDown("Atacar");
        habilidad1 = Input.GetButtonDown("Habilidad1");
        habilidad2 = Input.GetButtonDown("Habilidad2");
        habilidad3 = Input.GetButtonDown("Habilidad3");
        saltar = Input.GetButtonDown("Jump");
        interactuar = Input.GetButtonDown("Interactuar");
        inventario = Input.GetButtonDown("Inventario");
        // interactuar = Input.GetButtonDown("interactuar");
        // interactuar = Input.GetButtonDown("interactuar");
        //MOV
        ejeX = Input.GetAxis("Horizontal");
        ejeY = Input.GetAxis("Vertical");

        DeterminarDireccionMirada();
    }

        private void DeterminarDireccionMirada() {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                direccionMirada.x = ejeX;
                direccionMirada.y = ejeY;
            }

        }

    
}
