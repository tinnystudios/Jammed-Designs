using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Better;
using System.IO;
public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    public string fileName;
    public Objective curObjective;


    public void Init()
    {
        Instance = this;
        BetterStreamingAssets.Initialize();

        string[] paths = BetterStreamingAssets.GetFiles("\\", "*.json", SearchOption.AllDirectories);

        var contents = File.ReadAllText(BetterStreamingAssets.Root + paths[Random.Range(0, paths.Length)]);
        curObjective = JsonConvert.DeserializeObject<Objective>(contents);
    }

    [ContextMenu("Save")]
    public void SaveData()
    {
        BetterStreamingAssets.Initialize();
        string jsonString = JsonConvert.SerializeObject(curObjective, Formatting.Indented);

        var sr = File.CreateText(BetterStreamingAssets.Root + fileName + ".json");
        sr.Write(jsonString);
        sr.Close();
    }

    [System.Serializable]
    public class Objective
    {
        [TextArea]
        public string FlavourText;
        public List<ItemTypeToHave> ItemsToHave;
        public List<SenseCounts> TagCount;
    }

    [System.Serializable]
    public class ItemTypeToHave
    {
        public ItemTag.ItemType type;
        public int Needed;
    }

    [System.Serializable]
    public class SenseCounts
    {
        public ItemTag.Tag sensation;
        public int Needed;
    }


    [System.Serializable]
    public class Progress
    {
        public Dictionary<int, int> ItemsPresent;
        public Dictionary<int, int> SenseValue;

        public Progress()
        {
            ItemsPresent = new Dictionary<int, int>();
            SenseValue = new Dictionary<int, int>();
        }
    }
}
