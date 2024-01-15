using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{

  //  public NivelDeExperiencia level;
  //  public Salud salud;
    public float[] position;
    public string scene;
    public int vidaActual;
    public int experienciaActual;
    //  public List<Item> inv;

    public PlayerData (PlayerController player)
    {
    //    level = player.nivelDeExperiencia;
     //   salud = player.salud;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        scene = SceneManager.GetActiveScene().name;

        vidaActual = player.salud.SaludActual;
        experienciaActual = player.nivelDeExperiencia.experienciaActual;
        //
        //
        // inv = Inventario.instance.Objetos();
    }




}
