using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    #region Fields
    [Header("References")]

    public GameManager gameManager;

    public TMP_Text scoreText;

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

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void AddScore(int score)
    {
        playerScore += score;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag  == "DrinkStation")
        {
            if (other.gameObject.name == "LagerTap")
            {
                gameManager.HandleCollision("Lager");
            }
            else if (other.gameObject.name == "CiderTap")
            {
                gameManager.HandleCollision("Cider");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Rum")
        {
            gameManager.HandleCollision("Rum");
        }

        if (other.gameObject.name == "SugarSyrup")
        {
            gameManager.HandleCollision("Sugar Syrup");
        }

        if (other.gameObject.name == "LimeJuice")
        {
            gameManager.HandleCollision("Lime Juice");
        }

        if (other.gameObject.name == "CocktailShaker")
        {
            gameManager.shakerCollected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.LeftCollider();
    }
}
