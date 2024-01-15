using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DinoController : MonoBehaviour
{

    public static DinoController instance;


    public float speed = 9.0f;
    public float thresholdDistance = 0.5f;
    public float patrolRadius = 2.0f;
    public Transform player;

    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        waypoints = new Vector3[4];
      //  TeleportToPlayer(); // Teletransporta a Dino junto al jugador

    }

    void Update()
    {
        // Intenta encontrar al jugador si aún no se ha asignado.
        if (player == null)
        {
            gameObject.SetActive(false); // Oculta a Dino

            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            if (playerGameObject != null)
            {
                player = playerGameObject.transform;
             //   TeleportToPlayer(); // Teletransporta a Dino junto al jugador

            }
        }

        // Si el jugador ha sido encontrado, procede con la lógica de patrulla.
        if (player != null)
        {
            gameObject.SetActive(true);
            UpdateWaypoints(); // Actualiza constantemente los waypoints basándose en la posición del jugador
            Patrol();
         //   TeleportToPlayer(); // Teletransporta a Dino junto al jugador

        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Intenta encontrar al jugador en la nueva escena.
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            player = playerGameObject.transform;
            TeleportToPlayer(); // Teletransporta a Dino junto al jugador al cargar la escena
        }
    }


    void UpdateWaypoints()
    {
        waypoints[0] = player.position + new Vector3(patrolRadius, 0, 0);
        waypoints[1] = player.position + new Vector3(-patrolRadius, 0, 0);
        waypoints[2] = player.position + new Vector3(0, patrolRadius, 0);
        waypoints[3] = player.position + new Vector3(0, -patrolRadius, 0);
    }

    void Patrol()
    {
        Vector3 targetWaypoint = waypoints[currentWaypointIndex];
        MoveTowards(targetWaypoint);

        if (Vector3.Distance(transform.position, targetWaypoint) < thresholdDistance)
        {
            //    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            currentWaypointIndex = Random.Range(0, waypoints.Length);

        }
    }

    void MoveTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        UpdateAnimator(direction.x, direction.y);
    }

    void UpdateAnimator(float horizontal, float vertical)
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }


    void TeleportToPlayer()
    {
        if (player != null)
        {
            // Genera una posición al azar alrededor del jugador dentro del radio especificado
            Vector3 randomPosition = player.position + Random.insideUnitSphere * patrolRadius;
            randomPosition.y = player.position.y; // Mantener la misma altura que el jugador

            transform.position = randomPosition; // Teletransporta a Dino a la nueva posición
        }
    }
}