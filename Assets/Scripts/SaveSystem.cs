using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    public static void Save(Tower tower)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.tt";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(tower);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/player.tt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
           
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            return data;
        }
        else
        {
            return null;
        }
    }
}
