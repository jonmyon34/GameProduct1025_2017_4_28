using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEraser : MonoBehaviour,Grabable
{

	public void Init()
	{

	}

	public void ManagedUpdate()
	{

	}

	public void Grabable()
	{
		Debug.Log("this");
		Destroy(this.gameObject);
	}
}