using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TObstacleScript : MonoBehaviour
{
	public GameObject VoiceManager;
	TVoiceManagerScript script;

	bool isGrabed = false;
	bool isRelease = false;

	void Init()
	{
		script = VoiceManager.GetComponent<TVoiceManagerScript>();
	}

	public void ManagedUpdate()
	{
		GrabCheck();


		if (isGrabed && !script.isPlObstacleGrabed)
		{
			IsGrabed();
		}

		if(isRelease && !script.isPlObstacleRelease)
		{
			IsRelease();
			isRelease = false;
		}
	}

	void GrabCheck()
	{
		if(false/*親にハンドがあるか探す処理*/)
		{
			isGrabed = true;
		}

		if(isGrabed/* && 親にオブジェクトがあるかどうかのチェック */)
		{
			isGrabed = false;
			isRelease = true;
		}
	}

	void IsGrabed()
	{
		script.isPlObstacleGrabed = true;
	}

	void IsRelease()
	{
		script.isPlObstacleRelease = true;
	}
}