using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//[RequireComponent(typeof(GeneradorTextHit))]
public class NivelDeExperiencia : MonoBehaviour
{
    private PlayerController player;
    private Salud salud;

    public Image barraDeExp;
    
 //   private GeneradorTextHit generadorText;
 //   private Rango rangoTextoLevelUp = new Rango() { min = 0, max = 0 };

    private int experienciaActual;
    private int expSiguienteNivel;
    private float razonExpNivelActual;

    public int nivel { get; set; }

    public int experiencia 
    {
        get { return experienciaActual; }
        set
        {
            experienciaActual = value;
            if (nivel > 1)
            {
                razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
                {
                    RevisarSiSubeDeNivel();
                   // while (razonExpNivelActual >= 1)
                  //  {
                   //     LevelUp();
                        //razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel; // Actualizar razonExpNivelActual

                   // }
                }
            }
            else
            {
                razonExpNivelActual = (float)(experienciaActual) / expSiguienteNivel;
                RevisarSiSubeDeNivel();
                // while (razonExpNivelActual >= 1)
              //  {
                //    LevelUp();
               // }
            }
            ActualizarBarraExp();
            ActualizarPanelDeAtributos();
        }
      
    }


    private void RevisarSiSubeDeNivel()
    {
        while(razonExpNivelActual >= 1)
        {
            LevelUp();
        }
    }


    // Start is called before the first frame update
    // void Start()
    void Awake()
    {
        nivel = 1;

        player = GetComponent<PlayerController>();
        salud = GetComponent<Salud>();

        // generadorText = GetComponent<GeneradorTextHit>();
        expSiguienteNivel = CurvaExperiencia(nivel);
        ActualizarBarraExp();
    }

    private int CurvaExperiencia(int nivel)
    {
        float funcionExperiencia = (Mathf.Log(nivel, 3f) + 20);
        int experiencia = Mathf.CeilToInt(funcionExperiencia);
        return experiencia;
    }

    private int CurvaExperienciaAcumulativa(int nivel)
    {
        int experiencia = 0;
        for(int i = 1; i < nivel; i++)
        {
            experiencia += CurvaExperiencia(i);
        }
        return experiencia;
    }

    private void LevelUp()
    {
        nivel++;
        ConfigurarSiguienteNivel();
        // generadorText.CrearTextoHit(generadorText.textoHit, "Nuevo Nivel", tranform, 0.4f, Color.cyan, rangoTextoLevelUp, rangoTextoLevelUp, 2f);
        razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
    }

    void ConfigurarSiguienteNivel()
    {
        expSiguienteNivel = CurvaExperiencia(nivel);
    }

    void ActualizarBarraExp()
    {
        barraDeExp.fillAmount = razonExpNivelActual;
    }

    private void ActualizarPanelDeAtributos()
    {
        PanelAtributos.instance.ActualizarTextoAtributos(player.atributosJugador, salud, this);
    }


}
