using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.UI;

public class CanvaPers : MonoBehaviour
{

    public static CanvaPers insta;

    public Image barraSalud;
    public Image barraDeExp;


    // Start is called before the first frame update
    void Awake()
    {
        if(CanvaPers.insta == null)
        {
            CanvaPers.insta = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public Image BarraSalud
    {
        get { return barraSalud; }
    }

    public Image BarraDeExp
    {
        get { return barraDeExp; }
    }
}
