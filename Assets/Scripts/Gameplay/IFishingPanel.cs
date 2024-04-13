using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class IFishingPanel : MonoBehaviour
{
	[SerializeField] private GameObject _root = null;
	[SerializeField] private InputActionReference _inputActionReference = null;

	[SerializeField] private float _hideDelay = 1.0f;
	[SerializeField] private float _maxTime = 30.0f;

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

	private float _timer = 0.0f;

	public void Show()
	{
		_timer = _maxTime;
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

		_timer -= Time.deltaTime;
		if (_timer <= 0.0f)
		{
			Failed();
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
