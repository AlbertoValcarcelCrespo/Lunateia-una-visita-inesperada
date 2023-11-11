using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistente : MonoBehaviour
{

    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
    // Start is called before the first frame update
   /* void Start()
    {
        NoMeDestruyas();
    }

    // Update is called once per frame
    private void NoMeDestruyas()
    {
        DontDestroyOnLoad(this);
    }*/




