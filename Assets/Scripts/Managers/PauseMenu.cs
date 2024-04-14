using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{

	public GameObject PausePanel;

	public static bool GameIsPaused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}


	}

	public void Pause()
	{
		PausePanel.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void Resume()
	{
		PausePanel.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Restart()
	{
		GameManager.Instance.Restart();
        Debug.Log("Restarting game");
    }
}

