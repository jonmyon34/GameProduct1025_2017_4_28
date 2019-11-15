using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
	

	public bool ChildIsOneCheck()
	{
		if (this.transform.childCount == 1)
			return true;
		else
			return false;
	}

	public void ManagedUpdate()
	{
		if(ChildIsOneCheck())
		{
			//childが1になったらItem側にフラグを渡して処理をさせる
			//noisyの場合のみ?
		}

		

		
	}
}