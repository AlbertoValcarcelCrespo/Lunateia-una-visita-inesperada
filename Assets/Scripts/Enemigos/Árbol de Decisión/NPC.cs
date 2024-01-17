using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 

    private DecisionNode rootNode;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private Transform target;
    public GameObject dialogueMark; 
    private bool isPlayerInRange = false; // Flag para saber si el jugador está cerca
    public GameObject panelDialogo; // Panel de UI para mostrar el diálogo
    [SerializeField] private string[] dialogues;
    [SerializeField] private UnityEngine.UI.Text dialogueText; 
    private int currentDialogueIndex = 0;

    [SerializeField] public string idMision;


    private Animator animator;
    private float horizontal;
    private float vertical;

    void Start()
    {
        panelDialogo.SetActive(false); // Asegura que el panel esté oculto inicialmente
        dialogueMark.SetActive(false); // Asegura que el marcador esté oculto al inicio

        target = pointA;
        animator = GetComponent<Animator>();
        // Construir el árbol aquí
        rootNode = new Decision(
            () => IsPlayerNear(),  //  () => /* Condición */,
            new ActionNode(() => GreetPlayer()), // /* Acción si verdadero */),
            new ActionNode(() => PatrolArea()));    // /* Acción si falso */));
    }

    void Update()
    {
        rootNode.MakeDecision();
        MoveTowardsTarget(); // Se moverá solo si IsPlayerNear es falso
    }


        private bool IsPlayerNear()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, GameManager.instance.jugador.transform.position);
        bool isNear = distanceToPlayer < 3f;
        return isNear;
    }

    private void GreetPlayer()
    {
        panelDialogo.SetActive(true);

          Debug.Log("Hola, jugador! Estás cerca de mí." + GameManager.instance.gestorMisiones.EncontrarMisionPorId(idMision).id + GameManager.instance.gestorMisiones.EncontrarMisionPorId(idMision).titulo);

        if (GameManager.instance.gestorMisiones.EncontrarMisionPorId(idMision).estado == EstadoMision.Completada)//(GameManager.instance.gestorMisiones.misiones[1].estado == EstadoMision.Completada)
        {
            dialogueText.text = dialogues[1];
        }
        else
        {
            dialogueText.text = dialogues[0];
        }

    }

    private void PatrolArea()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime; 
        float distanceToPlayer = Vector3.Distance(transform.position, GameManager.instance.jugador.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        // Calcula la dirección de movimiento
        Vector2 direction = (target.position - transform.position).normalized;
        horizontal = direction.x;
        vertical = direction.y;

        // Actualiza las variables del Animator
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);


        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target = target == pointA ? pointB : pointA; // Cambia el objetivo una vez alcanzado
        }
        if(distanceToPlayer <= 3)
        {
            speed = 0;
            if (Input.GetButtonDown("Jump"))
            {
                GreetPlayer();
            }
        }
        else
        {
            panelDialogo.SetActive(false);

            speed = 2f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }




}