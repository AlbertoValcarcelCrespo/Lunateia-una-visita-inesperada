using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform respawnPoint1; // Primer punto de respawn
    public Transform respawnPoint2; // Segundo punto de respawn

    void Start()
    {
        // Configura la posición del jugador al primer punto de respawn al inicio del juego
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = respawnPoint1.position;
        }
    }

    public void SetRespawnPoint1()
    {
        // Configura la posición del primer punto de respawn
        respawnPoint1.position = GetPlayerPosition();
    }

    public void SetRespawnPoint2()
    {
        // Configura la posición del segundo punto de respawn
        respawnPoint2.position = GetPlayerPosition();
    }

    public void RespawnPlayer1()
    {
        // Respawn del jugador en el primer punto de respawn
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = respawnPoint1.position;
        }
    }

    public void RespawnPlayer2()
    {
        // Respawn del jugador en el segundo punto de respawn
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = respawnPoint2.position;
        }
    }

    private Vector3 GetPlayerPosition()
    {
        // Obtiene la posición actual del jugador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player.transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
