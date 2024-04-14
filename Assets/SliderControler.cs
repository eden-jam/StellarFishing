using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    }
}
