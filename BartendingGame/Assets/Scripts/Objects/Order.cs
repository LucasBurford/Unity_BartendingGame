using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    // Name of the order i.e. what drink it is
    public string orderName;

    // Image of the order
    public Sprite orderImage;

    // Time left to complete order
    public float timeLeft;

    // Decrease time by this amount
    public float decreaseTime;

    // Bool to determine if order is active
    public bool orderActive;

    public void Update()
    {
        if (orderActive)
        {
            timeLeft -= decreaseTime;
        }
    }
}
