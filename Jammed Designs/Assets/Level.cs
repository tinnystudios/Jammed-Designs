using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string ObjectiveMessage = "";
    public LevelRequirement LevelRequirement;

    //Cold
    //Warm
    //Rustic
    //Modern
    //Retro
    //Futuristic
}

[System.Serializable]
public class LevelRequirement
{
    public float TimeLimit = 90;
    [Range(-1,1)] public int Cold, Warm, Rustic, Modern, Retro, Futuristic;
}