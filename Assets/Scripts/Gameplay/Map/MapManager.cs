using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private Transform _selector = null;

    [SerializeField] private MapItem[] _planetTransforms = null;

	private void Start()
	{
		if (GameManager.Instance.LastMapSelected > -1)
		{
			_planetTransforms[GameManager.Instance.LastMapSelected].ActivateNext();
		}
		else
		{
			_planetTransforms[0].Activate();
		}
	}

	public void Validate(EnvironmentType environmentType, int index)
	{
		GameManager.Instance.OnSceneSelected(environmentType, index);
	}
}
