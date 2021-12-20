using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image background;

    public Color startCol;
    public Color endCol;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Colour
        // If slider value is between 35 and 45 essentially
        if (slider.value > 35)
        {
            // Set slider colour to green
            fill.color = new Color(0, 255, 0);
        }
        // Else if slider value is greater than 25 BUT less than 35
        else if (slider.value > 20 && slider.value < 30)
        {
            // Set slider colour to yellow
            fill.color = new Color(255, 230, 0);
        }
        // Else if slider value is less than 15
        else if (slider.value <= 15)
        {
            // Set slider colour to red
            fill.color = new Color(255, 0, 0);
        }
        #endregion

        float x = Mathf.PingPong(Time.time, 1);
        background.color = Color.Lerp(startCol, endCol, x);
    }
}
