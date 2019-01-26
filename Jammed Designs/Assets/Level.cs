using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string ObjectiveMessage = "";
    public float TimeLimit = 90;
    public LevelRequirement LevelRequirement;
}

[System.Serializable]
public class LevelRequirement
{
    [Range(-1,1)] public int Cold, Warm, Rustic, Modern, Retro, Futuristic;
}