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

    //  public Mision misionRequerida; // Referencia a la misión que debe completarse

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

        //return //(npc.misionParaActivar.estado == EstadoMision.Completada);
        return GameManager.instance.gestorMisiones.EncontrarMisionPorId(id).estado == EstadoMision.Completada ;
        //return misionRequerida != null && misionRequerida.estado == EstadoMision.Completada;
    }
}