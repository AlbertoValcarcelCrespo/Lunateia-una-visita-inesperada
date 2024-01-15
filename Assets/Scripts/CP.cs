using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP : MonoBehaviour
{ 

    public static CP insta;


// Start is called before the first frame update
void Awake()
{
    if (CP.insta == null)
    {
            CP.insta = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}
}
