using System.Collections.Generic;
using System.Collections;
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

    // Reference to create drink text
    public TMP_Text createDrinkText;

    // Reference to drink complete text
    public TMP_Text drinkCompleteText;

    // Reference to ingredient collected text
    public TMP_Text ingredientCollectedText;

    // Reference to all ingredients collected text
    public TMP_Text allCollectedText;
    private bool hasDisplayed;

    // Reference to order image
    public Image orderImage;

    // Reference to timer slider
    public Slider timerSlider;

    // Reference to drink completion slider
    public Slider drinkCompletionSlider;

    // Drinks images - store in memory
    public Sprite daiqImage, ofImage, margImage, pfmImage, lagerImage, ciderImage;
    #endregion

    #region Gameplay and spec
    [Header("Gameplay and spec")]

    // Drink completion rate
    [SerializeField]
    private float drinkCompletionRate;

    // Queue of orders
    public Queue<Order> orderQueue;

    // List to hold drink types
    [SerializeField]
    List<string> drinksList;

    // Hold current order
    Order currentOrder;

    // Bool to determine if timer has started
    [SerializeField]
    private bool timerStarted;

    // Bool to determine if an order is already up
    [SerializeField]
    private bool orderUp;

    // Enum to hold what drink needs to be created
    [SerializeField]
    private Drinks drinkToBeCreated;
    public enum Drinks
    {
        daiquiri,
        oldFashioned,
        margarita,
        passionfruitMartini,
        lager,
        cider
    }

    // Float to store drink completion
    [SerializeField]
    private float drinkCompletion;

    // Bool to determine if player can pull a pint
    [SerializeField]
    private bool canPullPint;

    // List of type ingredient to act as player inventory
    [SerializeField]
    private List<Ingredient> inventory;

    // Bool to determine if all ingredients have been collected
    [SerializeField]
    private bool allIngredientsCollected;

    // Bool to determine if player has collected shaker
    [SerializeField]
    private bool shakerCollected;

    public int shakeScore;
    #endregion

    #region Times Ingredients Collected
    [Header("Times Ingredients Collected")]

    #region Diaquiri
    public int rumCollected;
    public int sugarSyrupCollected;
    public int limeJuiceCollected;
    #endregion

    #endregion

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate values
        orderQueue = new Queue<Order>();
        drinksList = new List<string>();
        inventory = new List<Ingredient>();

        // Add drinks to list
        AddDrinks();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all ingredients are collected based on what drink needs to be made
        if (drinkToBeCreated == Drinks.daiquiri)
        {
            if (rumCollected == 1 && sugarSyrupCollected == 1 && limeJuiceCollected == 1 && !hasDisplayed)
            {
                DisplayAllIngredientsCollected();
                hasDisplayed = true;
                allIngredientsCollected = true;
            }
        }

        if (allIngredientsCollected && shakerCollected)
        {
            ShakeCocktail();
        }

        print(shakeScore);
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
                        drinkToBeCreated = Drinks.daiquiri;

                        currentOrder = newOrder;
                    }
                    break;

                // Case 2: Old Fasioned
                case 2:
                    {
                        newOrder.orderName = "Old Fasioned";
                        newOrder.orderImage = ofImage;
                        drinkToBeCreated = Drinks.oldFashioned;
                        currentOrder = newOrder;
                    }
                    break;

                // Case 3: Margarita
                case 3:
                    {
                        newOrder.orderName = "Margarita";
                        newOrder.orderImage = margImage;
                        drinkToBeCreated = Drinks.margarita;
                        currentOrder = newOrder;
                    }
                    break;

                // Case 4: Passionfruit Martini
                case 4:
                    {
                        newOrder.orderName = "Passionfruit Martini";
                        newOrder.orderImage = pfmImage;
                        drinkToBeCreated = Drinks.passionfruitMartini;
                        currentOrder = newOrder;
                    }
                    break;

                // Case 5: Pint of Lager
                case 5:
                    {
                        newOrder.orderName = "Pint of Lager";
                        newOrder.orderImage = lagerImage;
                        drinkToBeCreated = Drinks.lager;
                        currentOrder = newOrder;
                    }
                    break;

                // Case 6: Pint of Cider
                case 6:
                    {
                        newOrder.orderName = "Pint of Cider";
                        newOrder.orderImage = ciderImage;
                        drinkToBeCreated = Drinks.cider;
                        currentOrder = newOrder;
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

    public void RemoveOrder()
    {
        orderQueue.Dequeue();
        print("Order removed");
    }

    public void DisplayPullDrinkText(string tapType)
    {
        createDrinkText.text = "Hold E to pull " + tapType;
    }

    public void PullDrink()
    {
        if (Input.GetKey(KeyCode.E) && canPullPint)
        {
            // Fill drinkCompletion
            drinkCompletion += drinkCompletionRate;
            // Keep drink completion slider updated to drink completion
            drinkCompletionSlider.value += drinkCompletion / 10;

            // If drinkComplettion reaches or exceeds 100
            if (drinkCompletion >= 100)
            {
                // Stop player from further filling it
                drinkCompletion = 100;
                canPullPint = false;

                // Wait to generate a new order
                CompleteDrink();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && canPullPint)
        {
            if (drinkToBeCreated == Drinks.lager)
            {
                // Play lager pouring audio
                FindObjectOfType<AudioManager>().Play("LagerPouring");
            }

            if (drinkToBeCreated == Drinks.cider)
            {
                // Play cider pouring audio
                FindObjectOfType<AudioManager>().Play("CiderPouring");
            }
        }
    }

    public void ShakeCocktail()
    {
        if (allIngredientsCollected && shakerCollected)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                shakeScore++;
            }

            if (shakeScore >= 45)
            {
                CompleteDrink();
            }

            // One in 100 chance of shaker popping open
        }
    }

    private void CompleteDrink()
    {
        drinkCompleteText.gameObject.SetActive(true);
        drinkCompleteText.text = "Drink complete!";

        ResetAllIngredients();

        shakeScore = 0;

        shakerCollected = false;

        player.AddScore(10);

        StartCoroutine(WaitToGetNewOrder());
    }

    #region Coroutines

    IEnumerator WaitToGetNewOrder()
    {
        yield return new WaitForSeconds(2);

        drinkCompleteText.gameObject.SetActive(false);
        drinkCompletion = 0;
        drinkCompletionSlider.value = 0;
        canPullPint = true;
        CreateOrder();
    }

    IEnumerator WaitToRemoveIngredientCollectedText()
    {
        yield return new WaitForSeconds(1.5f);

        ingredientCollectedText.gameObject.SetActive(false);
    }

    IEnumerator WaitToRemoveAllCollectedText()
    {
        yield return new WaitForSeconds(3);

        allCollectedText.gameObject.SetActive(false);
    }

    #endregion

    #region Misc Methods
    public void HandleCollision(string ingredient)
    {
        // Check if player is at correct drink station
        // If drink to be created is a lager and player is at lager tap
        if (drinkToBeCreated == Drinks.lager && ingredient == "Lager")
        {
            // Display pull Lager text
            DisplayPullDrinkText("Lager");
            PullDrink();
        }
        // If drink to be created is cider and player is at cider tap
        else if (drinkToBeCreated == Drinks.cider && ingredient == "Cider")
        {
            // Display pull cider text
            DisplayPullDrinkText("Cider");
            PullDrink();
        }

        // If drink to be created is a daiquiri
        if (drinkToBeCreated == Drinks.daiquiri)
        {
            if (ingredient == "Rum" && rumCollected == 0)
            {
                // Add rum to inventory
                Ingredient rum = FindObjectOfType<Ingredient>();
                rum.ingredientName = "Rum";
                rumCollected++;

                inventory.Add(rum);

                DisplayIngredientCollected("Rum");
            }

            if (ingredient == "Sugar Syrup" && sugarSyrupCollected == 0)
            {
                // Add Sugar syrup to inventory
                Ingredient sugarSyrup = FindObjectOfType<Ingredient>();
                sugarSyrup.ingredientName = "Sugar Syrup";
                sugarSyrupCollected++;

                inventory.Add(sugarSyrup);

                DisplayIngredientCollected("Sugar Syrup");
            }

            if (ingredient == "Lime Juice" && limeJuiceCollected == 0)
            {
                // Add lime juice to inventory
                Ingredient limeJuice = FindObjectOfType<Ingredient>();
                limeJuice.ingredientName = "Lime Juice";
                limeJuiceCollected++;

                inventory.Add(limeJuice);

                DisplayIngredientCollected("Lime Juice");
            }
        }

    }

    private void DisplayIngredientCollected(string name)
    {
        ingredientCollectedText.gameObject.SetActive(true);
        ingredientCollectedText.text = name + " Collected!";
        StartCoroutine(WaitToRemoveIngredientCollectedText());
    }

    private void DisplayAllIngredientsCollected()
    {
        allCollectedText.gameObject.SetActive(true);
        allCollectedText.text = "All ingredients collected, add to a shaker and shake by pressing A and D!";

        StartCoroutine(WaitToRemoveAllCollectedText());
    }

    private void ResetAllIngredients()
    {
        rumCollected = 0;
        sugarSyrupCollected = 0;
        limeJuiceCollected = 0;
    }

    private void StepTimer()
    {
        timerSlider.value -= 1;
    }

    public void LeftCollider()
    {
        createDrinkText.text = "";
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
    #endregion
}
