using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Fields
    [Header("References")]
    // Reference to Player script
    public Player player;

    // Reference to order text
    public TMP_Text orderText;

    [Header("Gameplay and spec")]
    // Queue of orders
    public Queue<Order> orderQueue;

    // List to hold drink types
    [SerializeField]
    List<string> drinksList;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate values
        orderQueue = new Queue<Order>();
        drinksList = new List<string>();

        // Add drinks to list
        AddDrinks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateOrder()
    {
        // Instantiate a new order object
        Order order = FindObjectOfType<Order>();

        // Assign order a random drink
        order.orderName = drinksList[Random.Range(0, drinksList.Count)];

        DisplayOrder(order.orderName);
    }

    private void DisplayOrder(string order)
    {
        orderText.text = order;
    }

    public void RemoveOrder()
    {
        orderQueue.Dequeue();
        print("Order removed");
    }

    private void AddDrinks()
    {
        drinksList.Add("Daiquiri");
        drinksList.Add("Old Fasioned");
        drinksList.Add("Margarita");
        drinksList.Add("Passionfruit Martini");
    }
}
