using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SmashFishingPanel : IFishingPanel
{
    [SerializeField] private Image _image = null;
    [SerializeField] private InputActionReference _inputActionReference = null;

    void Start()
    {

	}

    void Update()
    {
        if (_inputActionReference.action.IsPressed())
        {

        }
    }
}
