using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitionAfterQuest : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 spawnPoint;
   [SerializeField] public InteraccionNPC npc;
    [SerializeField] public string id;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && MisionCompletada())
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            SceneManager.LoadScene(sceneToLoad);
            player.transform.position = spawnPoint;
        }
    }

    private bool MisionCompletada()
    {
        InteraccionNPC npc = GameObject.FindGameObjectWithTag("npc").GetComponent<InteraccionNPC>(); ;

        return GameManager.instance.gestorMisiones.EncontrarMisionPorId(id).estado == EstadoMision.Completada ;
    }
}