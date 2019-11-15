using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TItemScript : MonoBehaviour
{
	public GameObject player;
	public GameObject VoiceManager;
	TVoiceManagerScript script;

	bool isNoisyGrabed;
	bool isPlLightOff;
	bool isKeyGrabed;

	bool ImNoisy;
	bool ImKey;


	void Init()
	{
		script = VoiceManager.GetComponent<TVoiceManagerScript>();
	}

	public void ManagedUpdate()
	{
		PlLightOffCheck();


		if(isNoisyGrabed && !script.isPlNoisyGot)
		{
			IsPlNoisyGot();
		}

		if(isPlLightOff && !script.isPlLightOff)
		{
			IsPlNoisyGot();
		}

		if(isKeyGrabed && !script.isPlItemGot)
		{
			IsKeyGrabed();
		}
	}

	void PlLightOffCheck()
	{
		//playerのスクリプトからライトONOFFをチェックする
		//isNoisyGrabed = true;
	}

	void IsPlNoisyGot()
	{
		script.isPlNoisyGot = true;
	}

	void IsPlLightOff()
	{
		script.isPlLightOff = true;
	}

	void IsKeyGrabed()
	{
		script.isPlItemGot = true;
	}
}