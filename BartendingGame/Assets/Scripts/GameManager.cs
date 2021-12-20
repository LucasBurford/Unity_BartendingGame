using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]
    // Reference to Player script
    public Player player;

    // Reference to order text
    public TMP_Text orderText;

    // Reference to order image
    public Image orderImage;

    // Reference to timer slider
    public Slider timerSlider;

    // Drinks images - store in memory
    public Sprite daiqImage, ofImage, margImage, pfmImage, lagerImage, ciderImage;
    #endregion

    #region Gameplay and spec
    [Header("Gameplay and spec")]
    // Queue of orders
    public Queue<Order> orderQueue;

    // List to hold drink types
    [SerializeField]
    List<string> drinksList;

    // Bool to determine if timer has started
    [SerializeField]
    private bool timerStarted;

    // Bool to determine if an order is already up
    [SerializeField]
    private bool orderUp;
    #endregion

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
        // Only create an order if there currently isn't one up
        if (!orderUp)
        {
            // Set orderUp to true
            orderUp = true;

            // Instantiate a new order object
            Order newOrder = FindObjectOfType<Order>();

            // Generate random number to get a random order
            int rand = Random.Range(1, drinksList.Count);

            // Set order based on rand
            switch (rand)
            {
                // Case 1: Daiquiri
                case 1:
                    {
                        newOrder.orderName = "Daiquiri";
                        newOrder.orderImage = daiqImage;
                    }
                    break;

                // Case 2: Old Fasioned
                case 2:
                    {
                        newOrder.orderName = "Old Fasioned";
                        newOrder.orderImage = ofImage;
                    }
                    break;

                // Case 3: Margarita
                case 3:
                    {
                        newOrder.orderName = "Margarita";
                        newOrder.orderImage = margImage;
                    }
                    break;

                // Case 4: Passionfruit Martini
                case 4:
                    {
                        newOrder.orderName = "Passionfruit Martini";
                        newOrder.orderImage = pfmImage;
                    }
                    break;

                // Case 5: Pint of Lager
                case 5:
                    {
                        newOrder.orderName = "Pint of Lager";
                        newOrder.orderImage = lagerImage;
                    }
                    break;

                // Case 6: Pint of Cider
                case 6:
                    {
                        newOrder.orderName = "Pint of Cider";
                        newOrder.orderImage = ciderImage;
                    }
                    break;
            }

            // Display the order
            DisplayOrder(newOrder);

            // Only start timer if it hasn't already started
            if (!timerStarted)
            {
                // Set timerStarted to true
                timerStarted = true;

                // Start countdown timer
                InvokeRepeating("StepTimer", 0, 1);
            }
        }
        else
        {
            print("Order already up");
        }
    }

    private void DisplayOrder(Order pOrder)
    {
        orderText.text = pOrder.orderName;
        orderImage.sprite = pOrder.orderImage;
    }

    private void StepTimer()
    {
        timerSlider.value -= 1;
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
        drinksList.Add("Pint of lager");
        drinksList.Add("Pint of cider");
    }
}
