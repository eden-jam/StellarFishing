using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatAnimation : Singleton<PlayerBoatAnimation>
{
	[SerializeField] private Animator _playerAnimatior;
	[SerializeField] private Animator _dogAnimator;

	public void PlayCatch()
	{
		_playerAnimatior.Play("Catch");
		_dogAnimator.Play("Catch");
	}

	public void PlayLaunch()
	{
		_playerAnimatior.Play("Launch");
		_dogAnimator.Play("Launch");
	}

	public void PlayIdle()
	{
		_playerAnimatior.Play("Idle");
		_dogAnimator.Play("Idle");
	}

	public void PlayVictory()
	{
		_playerAnimatior.Play("Victory");
		_dogAnimator.Play("Victory");
	}
}
