using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class IFishingPanel : MonoBehaviour
{
	[SerializeField] private GameObject _root = null;
	[SerializeField] private InputActionReference _inputActionReference = null;

	[SerializeField] private float _hideDelay = 1.0f;

	private bool _isActive = false;

	/// <summary>
	/// Event triggered when fishing ended.
	/// </summary>
	private Action<bool> _fishingEndedEvent = null;

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
		_isActive = true;
		_root.SetActive(_isActive);
	}

	public void Hide()
	{
		_isActive = false;
		_root.SetActive(false);
	}

	protected void Succeed()
	{
		_isActive = false;
		StartCoroutine(DelayHide(_isActive, _hideDelay));
	}

	protected void Failed()
	{
		_isActive = false;
		StartCoroutine(DelayHide(_isActive, _hideDelay));
	}

	protected IEnumerator DelayHide(bool succeed, float delay)
	{
		yield return new WaitForSeconds(delay);
		Hide();
		_fishingEndedEvent?.Invoke(succeed);
	}

	public void Update()
	{
		if (_isActive == false)
		{
			return;
		}

		UpdateGame();

		if (_inputActionReference.action.WasPressedThisFrame())
		{
			OnPressed();
		}
	}

	protected abstract void UpdateGame();

	protected abstract void OnPressed();
}
