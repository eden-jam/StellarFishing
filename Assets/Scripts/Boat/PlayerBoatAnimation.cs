using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatAnimation : Singleton<PlayerBoatAnimation>
{
	[SerializeField] private Animator _playerAnimatior;
	[SerializeField] private Animator _dogAnimator;

	public void PlayLaunch()
	{
		_playerAnimatior.SetTrigger("Launch");
		_dogAnimator.SetTrigger("Launch");
	}

	public void PlayLoose()
	{
		_playerAnimatior.SetTrigger("Loose");
		_dogAnimator.SetTrigger("Loose");
	}

	public void PlayVictory()
	{
		_playerAnimatior.SetTrigger("Victory");
		_dogAnimator.SetTrigger("Victory");
	}
}
