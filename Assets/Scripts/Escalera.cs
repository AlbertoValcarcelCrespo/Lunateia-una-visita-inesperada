using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    private Collider2D miColisionador;
    void Start()
    {
        miColisionador = GetComponent<Collider2D>();
    }

}
