using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : Singleton<AudioManager>
{
	private void Start()
	{
		DontDestroyOnLoad(this);
	}
}
