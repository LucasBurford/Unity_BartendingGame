using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 35)
        {
            slider.image.color = new Color(39, 255, 0);
        }
        else if (slider.value > 25 && slider.value < 35)
        {
            slider.image.color = new Color(255, 255, 0);
        }
        else if (slider.value < 15)
        {
            slider.image.color = new Color(250, 30, 0);
        }
    }
}
