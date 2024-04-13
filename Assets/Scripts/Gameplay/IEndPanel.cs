using System;
using UnityEngine;

public class IEndPanel : MonoBehaviour
{
	/// <summary>
	/// Event triggered when 
	/// </summary>
	private Action _panelHiddedEvent = null;

	/// <summary>
	/// <inheritdoc cref="_panelHiddedEvent"/>
	/// </summary>
	public event Action PanelHiddedEvent
	{
		add { _panelHiddedEvent -= value; _panelHiddedEvent += value; }
		remove { _panelHiddedEvent -= value; }
	}

	public void Hide()
	{
		_panelHiddedEvent?.Invoke();
		gameObject.SetActive(false);
	}

	public void Update()
	{
		if (InputManager.Instance.WasPressedThisFrame)
		{
			Hide();
		}
	}
}
