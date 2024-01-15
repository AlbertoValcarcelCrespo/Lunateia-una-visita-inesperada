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

    public int experienciaActual;
    private int expSiguienteNivel;
    private float razonExpNivelActual;

    public int nivel { get; set; }

    public int experiencia 
    {
        get { return experienciaActual; }
        set
        {
            experienciaActual = value;
            razonExpNivelActual = CalcularRazonExpNivelActual();
            RevisarSiSubeDeNivel();
            ActualizarBarraExp();
            ActualizarPanelDeAtributos();
        }
      
    }


    private float CalcularRazonExpNivelActual()
    {
        if (nivel > 1)
        {
            return (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
        }
        else
        {
            return (float)experienciaActual / expSiguienteNivel;
        }
    }

    private void RevisarSiSubeDeNivel()
    {
        while(razonExpNivelActual >= 1)
        {
            LevelUp();
        }
    }


    void Awake()
    {
        nivel = 1;

    }


    // Start is called before the first frame update
    void Start()
   // void Awake()
    {
        nivel = 1;

        player = GetComponent<PlayerController>();
        salud = GetComponent<Salud>();
        barraDeExp = CanvaPers.insta.barraDeExp;

        // generadorText = GetComponent<GeneradorTextHit>();
        expSiguienteNivel = CurvaExperiencia(nivel);
        ActualizarBarraExp();
    }

    void Update()
    {
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
        player.salud.ModificarSaludBase(10);
        player.atributosJugador.AumentarAtaqueBase(1);
        ConfigurarSiguienteNivel();
        // generadorText.CrearTextoHit(generadorText.textoHit, "Nuevo Nivel", tranform, 0.4f, Color.cyan, rangoTextoLevelUp, rangoTextoLevelUp, 2f);
        razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
        ActualizarBarraExp();
    }

    void ConfigurarSiguienteNivel()
    {
        expSiguienteNivel = CurvaExperiencia(nivel);
    }

    public void ActualizarBarraExp()
    {
        if (barraDeExp)
        {
            // Calcular la proporción de la experiencia actual respecto a la experiencia necesaria para el siguiente nivel
            barraDeExp.fillAmount = razonExpNivelActual;
        }
    }

    public void ActualizarPanelDeAtributos()
    {
        PanelAtributos.instance.ActualizarTextoAtributos(player.atributosJugador, salud, this);
    }

    public void ReiniciarSExp()
    {
        nivel = 1;
        experienciaActual = 0;// salud; // Restablece la salud actual al máximo
                              //   SaludActual = salud;
        barraDeExp.fillAmount = 0;
        ActualizarPanelDeAtributos();
        //ActualizarBarraSalud(); // Actualiza la barra de salud visualmente
    }
}
