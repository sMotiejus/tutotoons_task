using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadJson : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public List<int> level_data;
    }

    [System.Serializable]
    public class Levels
    {
        public List<Level> levels;
    }

    public static Levels levels = new Levels();

    void Start()
    {
        string path = "Assets/Data/level_data.json";
        string text = File.ReadAllText(path);
        levels = JsonUtility.FromJson<Levels>(text);
    }

}
