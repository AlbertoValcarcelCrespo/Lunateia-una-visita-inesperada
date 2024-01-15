using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private InputPlayer inputJugador;
    //  private Transform transformada;

    private float horizontal;
    private float vertical;
    private Rigidbody2D miRigidbody2D;

    private bool corriendo;
    private int correrHashCode;

    private Animator animator;
    public Atributos atributosJugador;
    private Atacante atacante;

    private bool canJump;
    public static PlayerController instance;

    public LayerMask layerInteraccion;

    public Salud salud;
    public NivelDeExperiencia nivelDeExperiencia;




    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //ReiniciarEstado();
    }



    void Start()
    {
        salud = GetComponent<Salud>();
        //ReiniciarEstado();
        nivelDeExperiencia = GetComponent<NivelDeExperiencia>();
        //atributosJugador = GetComponent<Atributos>();
        inputJugador = GetComponent<InputPlayer>();
        //  transformada = GetComponent<Transform>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        correrHashCode = Animator.StringToHash("Corriendo");
        atacante = GetComponent<Atacante>();

        PanelAtributos.instance.ActualizarTextoAtributos(atributosJugador, salud, nivelDeExperiencia);
        PlayerController jugador = FindObjectOfType<PlayerController>();
        jugador.ReiniciarEstado();
        if (jugador != null)
        {
            jugador.GetComponent<Salud>().ReiniciarSalud();
            // Restablecer otros estados del jugador si es necesario
        }
    }

    void Update()
    {
        horizontal = inputJugador.ejeX;
        vertical = inputJugador.ejeY;

        if (salud.SaludActual > 0)
        {
            if (vertical != 0 || horizontal != 0)
            {
                animator.SetFloat("X", horizontal);
                animator.SetFloat("Y", vertical);

                animator.SetBool(correrHashCode, true);
            }
            else
            {
                animator.SetBool(correrHashCode, false);
            }

            if (Input.GetButtonDown("Atacar"))
            {
                // atacante.Atacar(inputJugador.direccionMirada, atributosJugador.ataque);//(new Vector2(horizontal, vertical), atributosJugador.ataque);
                animator.SetBool("Atacando", true);//Trigger("Atacar");
            }

            if (inputJugador.inventario)
            {
                PanelMenu.instance.AbrirCerrarInventario();
            }


            if (Input.GetKeyDown(KeyCode.G))
            {
                SaveSystem.SavePlayer(this);
                Inventario.instance.GuardarInventario();
                // PanelEquipamiento.instance.GuardarEquipamiento();
                Debug.Log("Datos Guardados");
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                PlayerData playerData = SaveSystem.LoadPlayer();
                //  salud = playerData.salud;
                //  nivelDeExperiencia = playerData.level;
                salud.SaludActual = playerData.vidaActual;
                salud.ActualizarBarraSalud(); // Actualiza la barra de salud en la UI
                nivelDeExperiencia.experienciaActual = playerData.experienciaActual;
                nivelDeExperiencia.ActualizarBarraExp(); // Actualiza la barra de experiencia en la UI
                                                         // nivelDeExperiencia.ActualizarPanelDeAtributos();
                Inventario.instance.CargarInventario();
                //  PanelEquipamiento.instance.CargarEquipamiento();
                transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
                GameManager.instance.gameOn();
                Time.timeScale = 1f;

                Debug.Log("Datos Cargados");
            }

        }
        else
        {
            animator.SetTrigger("Dead");
            GameManager.instance.gameOver();
            StartCoroutine(Dest(2));
            StartCoroutine(AlMenuPrincipal(1));
        }



    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 vectorVelocidad = new Vector2(horizontal, vertical) * atributosJugador.velocidad;//* Time.deltaTime;
        miRigidbody2D.velocity = vectorVelocidad;



    }

    void ControllerAtacar()
    {
        atacante.Atacar(inputJugador.direccionMirada, atributosJugador.ataque);
        animator.SetBool("Atacando", false);
    }


    public RaycastHit2D[] Interactuar()
    {
        if (gameObject == null) return null;

        RaycastHit2D[] circleCast = Physics2D.CircleCastAll(transform.position, GetComponent<CapsuleCollider2D>().size.x / 12, inputJugador.direccionMirada.normalized, 2f / 12, layerInteraccion);
        return circleCast;
    }

    IEnumerator AlMenuPrincipal(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0; // Detiene el tiempo una vez en el menú, si es necesario
        Destroy(gameObject);

    }

    IEnumerator Dest(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }



      public void ReiniciarEstado()
      {
          GetComponent<Salud>().ReiniciarSalud();
        //nivelDeExperiencia.nivel = 1;
        //   nivelDeExperiencia.experiencia = 0;
        //   nivelDeExperiencia.barraDeExp.fillAmount = 0;
        GetComponent<NivelDeExperiencia>().ReiniciarSExp();
        Inventario.instance.ReiniciarInventario(); // Añade esta línea para reiniciar el inventario
        PanelEquipamiento.instance.ReiniciarEquipamiento(); // Reiniciar el equipamiento

        // nivelDeExperiencia.experiencia = 0;
        // Reiniciar la experiencia

    }



    public void ConfigurarJugador(PlayerData data)
    {
        if (data != null)
        {
            //   transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            //   salud.SaludActual = data.vidaActual;
            //  nivelDeExperiencia.experienciaActual = data.experienciaActual;
            // Aplica cualquier otro dato necesario
            PlayerData playerData = SaveSystem.LoadPlayer();
            //  salud = playerData.salud;
            //  nivelDeExperiencia = playerData.level;
            salud.SaludActual = playerData.vidaActual;
            salud.ActualizarBarraSalud(); // Actualiza la barra de salud en la UI
            nivelDeExperiencia.experienciaActual = playerData.experienciaActual;
            nivelDeExperiencia.ActualizarBarraExp(); // Actualiza la barra de experiencia en la UI
                                                     // nivelDeExperiencia.ActualizarPanelDeAtributos();
            Inventario.instance.CargarInventario();
            //  PanelEquipamiento.instance.CargarEquipamiento();
            transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
            Debug.Log("Datos Cargados");
        }
    }



}