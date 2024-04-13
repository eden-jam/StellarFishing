using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManu : MonoBehaviour
{
    void Update()
    {
        if (InputManager.Instance.WasPressedThisFrame())
        {
            GameManager.Instance.OnSceneEnd();
        }
    }
}
