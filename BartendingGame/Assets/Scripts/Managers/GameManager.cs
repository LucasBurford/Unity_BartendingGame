﻿using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]

    #region General references

    // Reference to Player script
    public Player player;
    public PlayerMovement playerMovement;

    // Reference to ingredient images game object
    public GameObject ingredientImages;

    //  Shaking audio
    public AudioSource cocktailShaking;
    #endregion

    #region Text fields
    [Header("Text fields")]
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
    #endregion

    #region Image fields
    [Header("Image fields")]
    // Reference to order image
    public Image orderImage;

    // Reference to ingredient images
    public Image ingredient1Image, ingredient2Image, ingredient3Image;

    // Drinks images - store in memory
    public Sprite daiqImage, ofImage, margImage, pfmImage, lagerImage, ciderImage;

    // Ingredient images - store in memory
    public Sprite ingRum, ingSugarSyrup, ingLimeJuice, ingWhiskey, ingVodka, ingTequila, ingCointreau, ingPassoa, ingBitters, ingPassionfruitPuree;
    #endregion

    #region Sliders
    [Header("Sliders")]
    // Reference to timer slider
    public Slider timerSlider;

    // Reference to drink completion slider
    public Slider pintCompletionSlider;

    // Reference to cocktail completion slider
    public Slider cocktailCompletionSlider;
    #endregion

    #region Ingredient and shaker game objects
    [Header("Ingredient and shaker game objects")]

    // Store ingredient game objects
    public List<GameObject> ingredientGOList;
    //public GameObject rumGO;
    //public GameObject limeJuiceGO;
    //public GameObject sugarSyrupGO;
    //public GameObject tequilaGO;
    //public GameObject vodkaGO;
    //public GameObject cointreauGO;
    //public GameObject passoaGO;
    //public GameObject whiskeyGO;
    //public GameObject bittersGO;
    //public GameObject passionfruitPureeGO;
    //public GameObject shakerGO;
    #endregion

    #region Ingredient and shaker locations
    [Header("Ingredient and shaker locations")]
    public List<GameObject> ingredientLocList;
    //public Transform loc1;
    //public Transform loc2;
    //public Transform loc3;
    //public Transform loc4;
    //public Transform loc5;
    //public Transform loc6;
    //public Transform loc7;
    //public Transform loc8;
    //public Transform loc9;
    //public Transform loc10;
    //public Transform loc11;
    #endregion
    #endregion

    #region Gameplay and spec
    [Header("Floats and ints")]
    [Header("Gameplay and spec")]

    #region Floats and ints

    // Drink completion rate
    [SerializeField]
    private float drinkCompletionRate;

    // Float to store drink completion
    [SerializeField]
    private float pintCompletion;

    // Float to store timer max time
    [SerializeField]
    private float timerMaxTime;

    // Int to store shake score
    [SerializeField]
    private float shakeScore;

    // Float to store shakeScore deduction
    [SerializeField]
    private float shakeScoreReduce;

    // Store total number of drinks completed
    [SerializeField]
    private int drinksCompleted;
    #endregion

    #region Bools
    [Header("Bools")]

    // Bool to determine if an order is already up
    [SerializeField]
    private bool orderUp;

    // Bool to determine if player can pull a pint
    [SerializeField]
    private bool canPullPint;

    // Bool to determine if all ingredients have been collected
    [SerializeField]
    private bool allIngredientsCollected;

    // Bool to determine if player has collected shaker
    public bool shakerCollected;

    // Bool to determine if timer has started
    [SerializeField]
    private bool timerStarted;

    // Bool to determine if player is shaking cocktail
    [SerializeField]
    private bool shaking;
    #endregion

    #region Misc fields
    [Header("Misc fields")]

    // List of type ingredient to act as player inventory
    [SerializeField]
    private List<Ingredient> inventory;

    // Queue of orders
    public List<Order> orderList;

    // List to hold drink types
    [SerializeField]
    List<string> drinksList;

    // Hold current order
    Order currentOrder;

    // Enum to hold what drink needs to be created
    [SerializeField]
    private Drinks drinkToBeCreated;
    public enum Drinks
    {
        none,
        daiquiri,
        oldFashioned,
        margarita,
        passionfruitMartini,
        lager,
        cider
    }
    #endregion
    #endregion

    #region Times Ingredients Collected
    [Header("Times Ingredients Collected")]

    #region Diaquiri
    public int rumCollected;
    public int dSugarSyrupCollected;
    public int dLimeJuiceCollected;
    #endregion

    #region Margarita
    public int tequilaCollected;
    public int mLimeJuiceCollected;
    public int cointreauCollected;
    #endregion

    #region Old Fashioned
    public int whiskeyCollected;
    public int ofSugarSyrupCollected;
    public int bittersCollected;
    #endregion

    #region Passionfruit Martini
    public int vodkaCollected;
    public int passoaCollected;
    public int passionfruitPureeCollected;
    #endregion

    #endregion

    #region TESTING - REMOVE
    [Header("TESTING")]
    public bool TEST = true;
    #endregion

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate values
        orderList = new List<Order>();
        drinksList = new List<string>();
        inventory = new List<Ingredient>();
        ingredientGOList = new List<GameObject>();
        ingredientLocList = new List<GameObject>();

        drinkToBeCreated = Drinks.none;

        // Add ingredient game objects and locations to lists
        AddIngredientsToList();
        AddIngredientLocationsToList();

        // Add drinks to list
        AddDrinks();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all ingredients are collected based on what drink needs to be made
        if (drinkToBeCreated == Drinks.daiquiri)
        {
            if (rumCollected == 1 && dSugarSyrupCollected == 1 && dLimeJuiceCollected == 1 && !hasDisplayed)
            {
                DisplayAllIngredientsCollected();
                hasDisplayed = true;
                allIngredientsCollected = true;
            }
        }

        if (drinkToBeCreated == Drinks.margarita)
        {
            if (tequilaCollected == 1 && cointreauCollected == 1 && mLimeJuiceCollected == 1 &&!hasDisplayed)
            {
                DisplayAllIngredientsCollected();
                hasDisplayed = true;
                allIngredientsCollected = true;
            }
        }

        if (drinkToBeCreated == Drinks.oldFashioned)
        {
            if (whiskeyCollected == 1 && ofSugarSyrupCollected == 1 && bittersCollected == 1 && !hasDisplayed)
            {
                DisplayAllIngredientsCollected();
                hasDisplayed = true;
                allIngredientsCollected = true;
            }
        }

        if (drinkToBeCreated == Drinks.passionfruitMartini)
        {
            if (vodkaCollected == 1 && passoaCollected == 1 && passionfruitPureeCollected == 1 && !hasDisplayed)
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

        if (TEST)
        {
            ShakeCocktail();
        }
    }

    public void CreateOrder()
    {
        // Only create an order if there currently isn't one up
        if (!orderUp)
        {
            // Set orderUp to true
            // orderUp = true;

            RandomiseLocations();

            // Play new order ding
            FindObjectOfType<AudioManager>().Play("NewOrderDing");

            // Instantiate a new order object
            Order newOrder = FindObjectOfType<Order>();

            // Generate random number between 1 and max amount of drinks to get a random order
            int rand = Random.Range(1, drinksList.Count + 1);

            // Set order based on rand
            switch (rand)
            {
                // Case 1: Daiquiri 
                case 1:
                    {
                        newOrder.orderName = "Daiquiri";
                        newOrder.orderImage = daiqImage;
                        drinkToBeCreated = Drinks.daiquiri;
                    }
                    break;

                // Case 2: Old Fasioned 
                case 2:
                    {
                        newOrder.orderName = "Old Fasioned";
                        newOrder.orderImage = ofImage;
                        drinkToBeCreated = Drinks.oldFashioned;
                    }
                    break;

                // Case 3: Margarita 
                case 3:
                    {
                        newOrder.orderName = "Margarita";
                        newOrder.orderImage = margImage;
                        drinkToBeCreated = Drinks.margarita;
                    }
                    break;

                // Case 4: Passionfruit Martini 
                case 4:
                    {
                        newOrder.orderName = "Passionfruit Martini";
                        newOrder.orderImage = pfmImage;
                        drinkToBeCreated = Drinks.passionfruitMartini;
                    }
                    break;

                // Case 5: Pint of Lager
                case 5:
                    {
                        newOrder.orderName = "Pint of Lager";
                        newOrder.orderImage = lagerImage;
                        drinkToBeCreated = Drinks.lager;
                        canPullPint = true;
                    }
                    break;

                // Case 6: Pint of Cider
                case 6:
                    {
                        newOrder.orderName = "Pint of Cider";
                        newOrder.orderImage = ciderImage;
                        drinkToBeCreated = Drinks.cider;
                        canPullPint = true;
                    }
                    break;
            }

            // Add the new order to orderList
            currentOrder = newOrder;
            orderList.Add(newOrder);

            // Display the order and ingredients
            DisplayOrder(newOrder);

            // Reset timer - after each completion reduce by number of drinks completed to add tension
            timerSlider.value = timerMaxTime - drinksCompleted;

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

        DisplayIngredientImages();
    }

    private void RandomiseLocations()
    {
        // Set ingredient and shaker to random location
        for (int i = 0; i < ingredientGOList.Count; i++)
        {
            // Generate random number between 1 and location list count
            int rand = Random.Range(0, ingredientLocList.Count);

            // Move the ingredient GO to location GO at generated location
            ingredientGOList[i].transform.position = ingredientLocList[rand].transform.position;

            // Remove this specific location GO
            ingredientLocList.RemoveAt(rand);
        }

        // Repopulate location GO list after loop has ended
        AddIngredientLocationsToList();
    }

    private void DisplayOrder(Order pOrder)
    {
        orderText.text = pOrder.orderName;
        orderImage.sprite = pOrder.orderImage;
    }

    private void DisplayIngredientImages()
    {
        // Display correct ingredients based on what the order is
        switch (drinkToBeCreated)
        {
            // If current order is Daiquiri - rum, sugar syrup and lime juice DONE
            case Drinks.daiquiri:
                {
                    ingredient1Image.sprite = ingRum;
                    ingredient2Image.sprite = ingSugarSyrup;
                    ingredient3Image.sprite = ingLimeJuice;
                    ingredientImages.gameObject.SetActive(true);
                }
                break;

            // If current order is margarita - tequila, cointreau and lime juice 
            case Drinks.margarita:
                {
                    ingredient1Image.sprite = ingTequila;
                    ingredient2Image.sprite = ingCointreau;
                    ingredient3Image.sprite = ingLimeJuice;
                    ingredientImages.gameObject.SetActive(true);
                }
                break;

            // If current order is old fasioned - whiskey, sugar syrup and bitters
            case Drinks.oldFashioned:
                {
                    ingredient1Image.sprite = ingWhiskey;
                    ingredient2Image.sprite = ingSugarSyrup;
                    ingredient3Image.sprite = ingBitters;
                    ingredientImages.gameObject.SetActive(true);
                }
                break;

            // If current order is passionfruit martini - vodka, passoa and passionfruit puree
            case Drinks.passionfruitMartini:
                {
                    ingredient1Image.sprite = ingVodka;
                    ingredient2Image.sprite = ingPassoa;
                    ingredient3Image.sprite = ingPassionfruitPuree;
                    ingredientImages.gameObject.SetActive(true);
                }
                break;

            // If current order is lager
            case Drinks.lager:
                {
                    ingredientImages.gameObject.SetActive(false);
                }
                break;

            // If current order is cider
            case Drinks.cider:
                {
                    ingredientImages.gameObject.SetActive(false);
                }
                break;
        }
    }

    private void RemoveIngredientImages()
    {
        // Disable images
        ingredientImages.gameObject.SetActive(false);
    }

    public void RemoveOrder(int removeAt)
    {
        // Remove specific order from list
        orderList.RemoveAt(removeAt);
        print("Order removed");
    }

    public void DisplayPullDrinkText(string tapType)
    {
        createDrinkText.gameObject.SetActive(true);
        createDrinkText.text = "Hold E to pull " + tapType;
    }

    public void PullDrink()
    {
        if (Input.GetKey(KeyCode.E) && canPullPint)
        {
            // Fill drinkCompletion
            pintCompletion += drinkCompletionRate;
            // Keep drink completion slider updated to drink completion
            pintCompletionSlider.value += pintCompletion / 10;

            // If drinkComplettion reaches or exceeds 100
            if (pintCompletion >= 100)
            {
                // Stop player from further filling it
                pintCompletion = 100;
                canPullPint = false;

                // Wait to generate a new order
                CompleteDrink();
            }

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
        // Show shaker slider
        cocktailCompletionSlider.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            shakeScore++;
        }
        else if (shakeScore > 1)
        {
            shakeScore -= shakeScoreReduce;
        }

        if (shakeScore >= 45)
        {
            CompleteDrink();
        }

        cocktailCompletionSlider.value = shakeScore;

        // One in 100 chance of shaker popping open
    }

    private void CompleteDrink()
    {
        drinkCompleteText.gameObject.SetActive(true);
        drinkCompleteText.text = "Drink complete!";

        drinksCompleted++;

        cocktailCompletionSlider.gameObject.SetActive(false);

        createDrinkText.gameObject.SetActive(false);

        pintCompletion = 0;
        shakeScore = 0;

        pintCompletionSlider.value = 0;

        shakerCollected = false;
        canPullPint = false;
        orderUp = false;

        player.AddScore(10);

        ResetAllIngredients();
        RemoveIngredientImages();

        StartCoroutine(WaitToGetNewOrder());
    }

    #region Coroutines

    IEnumerator WaitToGetNewOrder()
    {
        yield return new WaitForSeconds(2);

        drinkCompleteText.gameObject.SetActive(false);
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
    public void HandleCollision(string collision)
    {
        #region Taps
        // Check if player is at correct drink station
        // If drink to be created is a lager and player is at lager tap
        if (drinkToBeCreated == Drinks.lager && collision == "Lager")
        {
            // Display pull Lager text
            DisplayPullDrinkText("Lager");
            PullDrink();
        }
        // If drink to be created is cider and player is at cider tap
        if (drinkToBeCreated == Drinks.cider && collision == "Cider")
        {
            // Display pull cider text
            DisplayPullDrinkText("Cider");
            PullDrink();
        }
        #endregion

        #region Cocktails
        // If drink to be created is a daiquiri
        if (drinkToBeCreated == Drinks.daiquiri)
        {
            if (collision == "Rum" && rumCollected == 0)
            {
                // Add rum to inventory
                Ingredient rum = FindObjectOfType<Ingredient>();
                rum.ingredientName = "Rum";
                rumCollected++;

                inventory.Add(rum);

                DisplayIngredientCollected("Rum");
            }

            if (collision == "SugarSyrup" && dSugarSyrupCollected == 0)
            {
                // Add Sugar syrup to inventory
                Ingredient sugarSyrup = FindObjectOfType<Ingredient>();
                sugarSyrup.ingredientName = "Sugar Syrup";
                dSugarSyrupCollected++;

                inventory.Add(sugarSyrup);

                DisplayIngredientCollected("Sugar Syrup");
            }

            if (collision == "LimeJuice" && dLimeJuiceCollected == 0)
            {
                // Add lime juice to inventory
                Ingredient limeJuice = FindObjectOfType<Ingredient>();
                limeJuice.ingredientName = "Lime Juice";
                dLimeJuiceCollected++;

                inventory.Add(limeJuice);

                DisplayIngredientCollected("Lime Juice");
            }
        }

        // If drink to be created is a marg
        if (drinkToBeCreated == Drinks.margarita)
        {
            if (collision == "Tequila" && tequilaCollected == 0)
            {
                tequilaCollected++;
                DisplayIngredientCollected("Tequila");
            }

            if (collision == "LimeJuice" && mLimeJuiceCollected == 0)
            {
                mLimeJuiceCollected++;
                DisplayIngredientCollected("Lime Juice");
            }

            if (collision == "Cointreau" && cointreauCollected == 0)
            {
                cointreauCollected++;
                DisplayIngredientCollected("Cointreau");
            }
        }

        // If drink to be created is an old fasioned
        if (drinkToBeCreated == Drinks.oldFashioned)
        {
            if (collision == "Whiskey" && whiskeyCollected == 0)
            {
                whiskeyCollected++;
                DisplayIngredientCollected("Whiskey");
            }

            if (collision == "SugarSyrup" && ofSugarSyrupCollected == 0)
            {
                ofSugarSyrupCollected++;
                DisplayIngredientCollected("Sugar Syrup");
            }

            if (collision == "Bitters" && bittersCollected == 0)
            {
                bittersCollected++;
                DisplayIngredientCollected("Bitters");
            }
        }

        // If drink to be created is a passionfruit martini
        if (drinkToBeCreated == Drinks.passionfruitMartini)
        {
            if (collision == "Vodka" && vodkaCollected == 0)
            {
                vodkaCollected++;
                DisplayIngredientCollected("Vodka");
            }

            if (collision == "Passoa" && passoaCollected == 0)
            {
                passoaCollected++;
                DisplayIngredientCollected("Passoa");
            }

            if (collision == "PassionfruitPuree" && passionfruitPureeCollected == 0)
            {
                passionfruitPureeCollected++;
                DisplayIngredientCollected("Passionfruit puree");
            }
        }
        #endregion

        if (collision == "CocktailShaker")
        {
            if (!allIngredientsCollected)
            {
                print("Collect all ingredients first!");
            }
            else
            {
                shakerCollected = true;
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
        dSugarSyrupCollected = 0;
        dLimeJuiceCollected = 0;

        tequilaCollected = 0;
        cointreauCollected = 0;
        mLimeJuiceCollected = 0;

        whiskeyCollected = 0;
        ofSugarSyrupCollected = 0;
        bittersCollected = 0;

        vodkaCollected = 0;
        passoaCollected = 0;
        passionfruitPureeCollected = 0;
    }

    private void StepTimer()
    {
        timerSlider.value -= 1;
    }

    public void LeftCollider()
    {
        createDrinkText.text = "";
    }

    private void AddIngredientsToList()
    {
        ingredientGOList.Add(GameObject.Find("Rum"));
        ingredientGOList.Add(GameObject.Find("SugarSyrup"));
        ingredientGOList.Add(GameObject.Find("LimeJuice"));
        ingredientGOList.Add(GameObject.Find("Whiskey"));
        ingredientGOList.Add(GameObject.Find("Passoa"));
        ingredientGOList.Add(GameObject.Find("PassionfruitPuree"));
        ingredientGOList.Add(GameObject.Find("Bitters"));
        ingredientGOList.Add(GameObject.Find("Tequila"));
        ingredientGOList.Add(GameObject.Find("Cointreau"));
        ingredientGOList.Add(GameObject.Find("Vodka"));
        ingredientGOList.Add(GameObject.Find("CocktailShaker"));
    }

    private void AddIngredientLocationsToList()
    {
        ingredientLocList.Add(GameObject.Find("Loc1"));
        ingredientLocList.Add(GameObject.Find("Loc2"));
        ingredientLocList.Add(GameObject.Find("Loc3"));
        ingredientLocList.Add(GameObject.Find("Loc4"));
        ingredientLocList.Add(GameObject.Find("Loc5"));
        ingredientLocList.Add(GameObject.Find("Loc6"));
        ingredientLocList.Add(GameObject.Find("Loc7"));
        ingredientLocList.Add(GameObject.Find("Loc8"));
        ingredientLocList.Add(GameObject.Find("Loc9"));
        ingredientLocList.Add(GameObject.Find("Loc10"));
        ingredientLocList.Add(GameObject.Find("Loc11"));
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
