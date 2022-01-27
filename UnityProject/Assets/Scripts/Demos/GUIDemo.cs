using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIDemo : MonoBehaviour
{
    public TMP_Text text;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if(slider) slider.value = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Okaerinasai";
    }

    public void ButtonClicked()
    {
        print("Clicked");
    }

    public void SliderUpdate(float value)
    {
        Time.timeScale = value;
    }
}
