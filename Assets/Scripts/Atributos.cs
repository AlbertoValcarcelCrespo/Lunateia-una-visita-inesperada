using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Atributo
{
    velocidad,
    ataque,
    Salud
}


[CreateAssetMenu(menuName = "ScriptableObjects/Atributos")]
public class Atributos : ScriptableObject
{



    [SerializeField]
    private int velocidadBase;
    [SerializeField]
    private int ataqueBase;

    private int velocidadModificador;
    private int ataqueModificador;

   // private int velocidadModificador { get { return velocidadBase + velocidadModificador; } }
   // private int ataqueModificador {  get {  return ataqueBase + ataqueModificador; } }

    public int velocidad { get { return velocidadBase + velocidadModificador; } }
    public int ataque { get { return ataqueBase + ataqueModificador; } }

    //   public int maxHealth;
    //  public int health;
    //  public int exp;
    // public int level;

    public void AumentarVelocidadBase(int cantidad)
    {
        velocidadBase += cantidad;
    }

    public void AumentarAtaqueBase(int cantidad)
    {
        ataqueBase += cantidad;
    }






    private void ModificarSalud(Salud salud, int Cantidad)
    {
        salud.ModificadorSalud += Cantidad;
    }

    public void ActualizarEquipamiento(List<Equipamiento> equipamientos)
    {
        ResetearModificadores();
        foreach(Equipamiento equipo in equipamientos)
        {
            velocidadModificador += equipo.velocidad;
            ataqueModificador += equipo.ataque;

            GameManager.instance.jugador.GetComponent<Salud>().ModificadorSalud += equipo.salud;
        }

        PanelAtributos.instance.ActualizarTextoAtributos(this, GameManager.instance.jugador.GetComponent<Salud>(), GameManager.instance.jugador.GetComponent<NivelDeExperiencia>());
        GameManager.instance.jugador.GetComponent<Salud>().ActualizarBarraSalud();

    }

    private void ResetearModificadores()
    {
        velocidadModificador = 0;
        ataqueModificador = 0;

        GameManager.instance.jugador.GetComponent<Salud>().ModificadorSalud = 0;
    }

    public void ModificarAtributo(Atributo atributo, int cantidad)
    {
        switch (atributo)
        {
            case Atributo.velocidad:
                velocidadModificador += cantidad;

                break;

            case Atributo.ataque:
                ataqueModificador += cantidad;

                break;

            case Atributo.Salud:

                break;

            default:
                Debug.Log("ninguna de las anteriores");
                break;
        }
    }


}
