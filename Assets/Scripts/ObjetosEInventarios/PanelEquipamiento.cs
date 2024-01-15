using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelEquipamiento : MonoBehaviour
{
    public static PanelEquipamiento instance;
    public Atributos atributos;
    public CasillaEquipamiento[] casillaEquipamientos;
    public List<Equipamiento> equipamientos = new List<Equipamiento>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            casillaEquipamientos = GetComponentsInChildren<CasillaEquipamiento>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ActualizarUIEquipamiento();
    }

    private void ActualizarUIEquipamiento()
    {
        // Asumiendo que tienes un método que devuelve todas las casillas de equipamiento de UI
        CasillaEquipamiento[] casillasEquipamientoUI = GetComponentsInChildren<CasillaEquipamiento>(true);

        // Resetea todas las casillas de equipamiento
        foreach (var casilla in casillasEquipamientoUI)
        {
            casilla.ResetearCasilla();
        }

        // Recorre los ítems equipados y actualiza las casillas correspondientes
        foreach (var equipamiento in equipamientos)
        {
            foreach (var casilla in casillasEquipamientoUI)
            {
                if (casilla.tipoDeEquipamiento == equipamiento.tipoDeEquipamiento)
                {
                    casilla.AñadirObjeto(equipamiento, 1);
                    break;
                }
            }
        }
    }



    public Equipamiento EquiparObjeto(Equipamiento equipamiento)
    {
        foreach (CasillaEquipamiento casillaEquipo in casillaEquipamientos)
        {
            if (equipamiento.tipoDeEquipamiento == casillaEquipo.tipoDeEquipamiento)
            {
                if (!casillaEquipo.itemAlmacenado)
                {
                    Debug.Log("Casilla vacia");
                    AgregarEquipo(equipamiento, casillaEquipo);
                    equipamiento.estaEquipado = true; // Marcar como equipado
                                                      //  PanelAtributos.instance.ActualizarTextoAtributos(atributos, GameManager.instance.jugador.salud, GameManager.instance.jugador.nivelDeExperiencia);
                                                      // PanelAtributos.instance.ActualizarTextoAtributos(atributos, PlayerController.instance.salud, PlayerController.instance.nivelDeExperiencia);

                    return null;
                }
                else
                {
                    Equipamiento objetoEquipado = casillaEquipo.itemAlmacenado as Equipamiento;
                    AgregarEquipo(equipamiento, casillaEquipo);
                    // PanelAtributos.instance.ActualizarTextoAtributos(atributos, PlayerController.instance.salud, PlayerController.instance.nivelDeExperiencia);

                    return objetoEquipado;
                }
            }
           // PanelAtributos.instance.ActualizarTextoAtributos(atributos, PlayerController.instance.salud, PlayerController.instance.nivelDeExperiencia);

        }
        return null;
    }

    public void AgregarEquipo(Equipamiento equipamiento, CasillaEquipamiento casillaEquipo)
    {
        casillaEquipo.AñadirObjeto(equipamiento, 1);
        equipamientos.Add(equipamiento);
        equipamiento.estaEquipado = true; // Marcar como equipado
        Inventario.instance.RemoverObjeto(equipamiento);
        //Atributos ActualizarEquipamiento()
        atributos.ActualizarEquipamiento(equipamientos);
    }

    public void RemoverEquipo(Equipamiento equipamiento)
    {
        equipamientos.Remove(equipamiento);
        equipamiento.estaEquipado = false; // Marcar como no equipado
        //Atributos ActualizarEquipamiento()
        //Inventario.instance.AgregarObjeto(equipamiento, 1);
        atributos.ActualizarEquipamiento(equipamientos);
    }


    public void ReiniciarEquipamiento()
    {
        equipamientos.Clear(); // Limpia la lista de equipamientos
        foreach (CasillaEquipamiento casilla in casillaEquipamientos)
        {
            casilla.ResetearCasilla(); // Asumiendo que tienes un método para resetear la casilla de equipamiento
        }
        ActualizarUIEquipamiento(); // Actualiza la UI de equipamiento
    }


}