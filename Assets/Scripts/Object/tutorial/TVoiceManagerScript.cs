using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVoiceManagerScript : MonoBehaviour
{
	public bool startFlg;
	public bool isPlObstacleGrabed;
	public bool isPlObstacleRelease;
	public bool isPlNoisyGot;
	public bool isPlLightOff;
	public bool isPlItemGot;
	public bool tutorialEndFlg;

	//スタートする→PLが障害物を持つ→PLが障害物を手放す→PLがNoisyを持つ→PLがライトを消す→PLがItemを取得する→
	//→チュートリアルが終わる


	public void Start()
	{
		startFlg = false;
	}

	public void PlObstacleGrabed()
	{
		isPlObstacleGrabed = false;
	}

	public void PlObstacleRelease()
	{
		isPlObstacleRelease = false;
	}

	public void PlNoisyGot()
	{
		isPlNoisyGot = false;
	}

	public void PlLightOff()
	{
		isPlLightOff = false;
	}

	public void PlItemGot()
	{
		isPlItemGot = false;
	}
	
	public void TutorialEnd()
	{
		tutorialEndFlg = false;
	}
}