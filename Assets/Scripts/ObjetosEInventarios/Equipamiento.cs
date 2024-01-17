using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipo
{
    casco, armadura, arma
}

[CreateAssetMenu(menuName = "ObjetosEscriptables/Items/Equipamiento")]
public class Equipamiento : Item
{
    public Equipo tipoDeEquipamiento;
    public int salud;
    public int ataque;
    public int velocidad;

    public override bool UsarItem()
    {
        Equipamiento equipamientoActualmenteEquipado = PanelEquipamiento.instance.EquiparObjeto(this);
        if (equipamientoActualmenteEquipado)
        {
            PanelEquipamiento.instance.RemoverEquipo(equipamientoActualmenteEquipado);
        }

        return true;
    }


}