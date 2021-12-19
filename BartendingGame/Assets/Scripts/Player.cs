using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields
    [Header("References")]
    GameManager gameManager;

    [Header("Gameplay and spec")]
    // Player name
    [SerializeField]
    private string playerName;
    public string PlayerName
    {
        get { return playerName; }
    }

    // Player score
    [SerializeField]
    private int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        print("Player Name: " + playerName);
        print("Player Score: " + playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void AddScore(int score)
    {
        playerScore = score;
    }
}
