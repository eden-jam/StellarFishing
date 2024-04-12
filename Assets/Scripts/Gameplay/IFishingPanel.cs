using System;
using UnityEngine;

public class IFishingPanel : MonoBehaviour
{
    [SerializeField] private GameObject _root = null;


	/// <summary>
	/// Event triggered when fishing ended.
	/// </summary>
	protected Action<bool> _fishingEndedEvent = null;

	/// <summary>
	/// <inheritdoc cref="_fishingEndedEvent"/>
	/// </summary>
	public event Action<bool> FishingEndedEvent
	{
		add { _fishingEndedEvent -= value; _fishingEndedEvent += value; }
		remove { _fishingEndedEvent -= value; }
	}

	public void Show()
	{
		_root.SetActive(true);
	}

	public void Hide()
	{
		_root.SetActive(true);
	}

	public bool IsActive()
    {
		return _root.activeSelf;
	}
}
