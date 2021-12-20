using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) == 1)
        {
            FindObjectOfType<AudioManager>().Play("GlassClink1");
        }
    }
}
