using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private readonly string secretCode = "dontttknoww";
    private const string saveVariablesKey = "INK_VARIABLES";
    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileId)
    {
        //base case: if profileId is null, return right away
        if (profileId == null) return null;
        // insert profileId between OS path and fileName
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption)
                {
                    dataToLoad = EncrypDecrypt(dataToLoad);
                }
                //deserialize the data from JSON back into C# object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void Save(GameData data, string profileId)
    {
        //base case: if profileId is null, return right away
        if (profileId == null) return;

        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        try
        {
            //create the directory the file wil be written to if it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the C# game data object into JSON
            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryption)
            {
                dataToStore = EncrypDecrypt(dataToStore);
            }
            //write the serialize data to the file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public void Delete(string profileId)
    {
        if (profileId == null) return;
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        // Debug.Log("Delete Profile: " + profileId);
        try
        {
            if (File.Exists(fullPath))
            {
                Directory.Delete(Path.GetDirectoryName(fullPath), true);
                PlayerPrefs.DeleteKey(saveVariablesKey + profileId);
            }
            else
            {
                Debug.LogWarning("Try to delete profile data, but data was not found at path: " + fullPath);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to delete profile data for profileId: " + profileId + " at path: " + fullPath + "\n" + e);
        }

    }
    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        //loop ove all directory names in the data directory path
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        foreach (DirectoryInfo dirInfo in dirInfos)
        {
            string profileId = dirInfo.Name;

            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping because not save file");
                continue;
            }
            //if here that means found save data, push it in dictionary
            GameData profileData = Load(profileId);

            if (profileData != null)
            {
                profileDictionary.Add(profileId, profileData);
            }
            else
            {
                Debug.LogError("Tried to load but sth went wrong. ProfileId: " + profileId);
            }

        }
        return profileDictionary;
    }
    public string GetMostRecentlyUpdateProfileId()
    {
        string mostRecentProfileId = null;
        Dictionary<string, GameData> profilesGameData = LoadAllProfiles();
        foreach (KeyValuePair<string, GameData> pair in profilesGameData)
        {
            string profileId = pair.Key;
            GameData gameData = pair.Value;

            if (gameData == null) continue;

            if (mostRecentProfileId == null)
            {
                mostRecentProfileId = profileId;
            }
            else
            {
                DateTime mostRecentDateTime = DateTime.FromBinary(profilesGameData[mostRecentProfileId].lastUpdated);
                DateTime newDateTime = DateTime.FromBinary(gameData.lastUpdated);

                if (newDateTime > mostRecentDateTime)
                {
                    mostRecentProfileId = profileId;
                }
            }

        }
        return mostRecentProfileId;
    }
    private string EncrypDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ secretCode[i % secretCode.Length]);
        }
        return modifiedData;
    }
}
