using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    public static string LastLoadedScene { get; private set; }


    public static void SavePlayer (PlayerController player)
    {
        PlayerData data = new PlayerData(player);
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static PlayerData LoadPlayer()
    {

        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            PlayerData data = (PlayerData) formatter.Deserialize(stream);
            stream.Close();
            LastLoadedScene = data.scene;

            SceneManager.LoadScene(data.scene);
            //Salud.ActualizarBarraSalud();


            return data;


        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }


    }





}
