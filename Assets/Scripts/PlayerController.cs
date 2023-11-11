using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private InputPlayer inputJugador;
    private Transform transformada;

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

    // private bool estaEnSuelo = false;
    // public Transform comprobadorSuelo;
    // [SerializeField] private float radioComprobadorSuelo = 0.1f;
    // [SerializeField] private LayerMask mascaraSuelo;

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
    }



    void Start()
    {
        //atributosJugador = GetComponent<Atributos>();
        inputJugador = GetComponent<InputPlayer>();
        transformada = GetComponent<Transform>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        correrHashCode = Animator.StringToHash("Corriendo");
        atacante = GetComponent<Atacante>();
      //  mascaraSuelo = LayerMask.GetMask("Ground");
      //  comprobadorSuelo = transform.Find("Cube");
    //    Debug.Log("comprobadorSuelo: " + comprobadorSuelo);
    //    Debug.Log("mascaraSuelo: " + mascaraSuelo);
    }

    void Update()
    {
        horizontal = inputJugador.ejeX;
        vertical = inputJugador.ejeY;



        if (vertical != 0 || horizontal !=0)
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



            //       if(Input.GetButtonDown("Jump") && estaEnSuelo)
            //      {
            //         miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, fuerzaSalto);
            //     }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    //    estaEnSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobadorSuelo, mascaraSuelo);

        //MOV
        //Vector2 nuevaPosicion = transformada.position + new Vector3(velocidad * horizontal*Time.deltaTime, velocidad * vertical*Time.deltaTime, 0);
        //transformada.position = nuevaPosicion;
        Vector2 vectorVelocidad = new Vector2(horizontal, vertical) * atributosJugador.velocidad;//* Time.deltaTime;
        //miRigidbody2D.AddForce(fuerza);
        miRigidbody2D.velocity = vectorVelocidad; 


        /*
        if(Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
        }
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
            //  gameObject.transform.Translate(50f * Time.deltaTime, 0, 0);
        }
        ManageJump();
        */
    }

    void ControllerAtacar()
    {
        atacante.Atacar(inputJugador.direccionMirada, atributosJugador.ataque);
        animator.SetBool("Atacando", false);
    }




   /* void ManageJump()
    {
        if(gameObject.transform.position.y <= 0)
        {
            canJump = true;
        }

        if (Input.GetKey("up") && canJump && gameObject.transform.position.y < 10)
        {
            gameObject.transform.Translate(0, 50f * Time.deltaTime, 0);
        }
        else
        {
            canJump = false;
            if(gameObject.transform.position.y > 0)
            {
                gameObject.transform.Translate(0, -50f * Time.deltaTime, 0);
            }
        }

    }*/


}
