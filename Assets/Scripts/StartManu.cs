using UnityEngine;

public class StartManu : MonoBehaviour
{
	void Update()
	{
		if (InputManager.Instance.WasPressedThisFrame())
		{
			AudioManager.Instance.PlayTransitionSound();
			AudioManager.Instance.PlayClicSound();
			GameManager.Instance.OnSceneEnd();
		}
	}
}
