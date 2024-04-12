using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public GameObject PausePanel;
}

// Update is called once per frame
void Update()
{

}

public void Pause()
{
    PausePanel.SetActive(true);
    Time.timeScale = 0;
}

}

