using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using TMPro;
public class save : MonoBehaviour
{
    [System.Serializable]
    public class gameFile
    {
        public bool tutorialLevel;
        public int level;
        public int exp;
        public int coins;
        public int crystal;
        public bool autoSave;
        public bool[] Leveltask;
        public bool[] loginDay;
        public int totalLogin;
        public int avatorIndex;
        public bool[] emotes;
        public bool[] bpCollected;
        public int bpLevel;
        public int bpExp;
        public bool[] levelSelection;
    }
    public gameFile gameFile_;
    public string saveSlotpath0;
    public TMP_Text autoSaveText;
    void Awake()
    {
        DontDestroyOnLoad(this);
        saveSlotpath0 = Application.persistentDataPath + "/gameData.dat";

        if (File.Exists(saveSlotpath0))
        {
            Load();
        }
        else
        {
            Save();
        }

        if (gameFile_.autoSave)
        {
            Debug.Log("Auto saved enabled");
            InvokeRepeating("Save", 0, 60);
        }
    }
    void Update()
    {
        if (gameFile_.autoSave)
        {
            autoSaveText.text = "Auto save enabled";
        }
        else
        {
            autoSaveText.text = null;
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(saveSlotpath0, FileMode.OpenOrCreate);

        try
        {
            bf.Serialize(stream, gameFile_);
        }
        catch (SerializationException error)
        {
            Debug.LogWarning(error.Message);
        }
        finally
        {
            stream.Close();
        }
    }
    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream stream = new FileStream(saveSlotpath0, FileMode.Open);

        try
        {
            gameFile loadedData = (gameFile)bf.Deserialize(stream);
            gameFile_ = loadedData;
        }
        catch (SerializationException error)
        {
            Debug.LogWarning(error.Message);
        }
        finally
        {
            stream.Close();
        }
}
    void OnApplicationQuit()
    {
        if (File.Exists(saveSlotpath0))
        {
            Save();
        }
    }
}
