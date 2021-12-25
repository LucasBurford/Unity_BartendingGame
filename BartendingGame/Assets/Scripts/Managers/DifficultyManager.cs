using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty
    {
        easy, 
        normal,
        hard
    }
    public Difficulty difficulty;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public Difficulty GetDifficulty()
    {
        return difficulty;
    }
}
