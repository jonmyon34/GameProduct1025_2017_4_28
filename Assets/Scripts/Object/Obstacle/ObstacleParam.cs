using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParam : MonoBehaviour
{
	public bool ObstacleIsChild()
	{
		if (this.gameObject.transform.parent != null)
		{
			Debug.Log("is child");
			return true;
		}
		else
		{
			Debug.Log("is not child");
			return false;
		}
	}

	public bool ObstacleIsGrabed()
	{
		var parent = this.gameObject.transform.parent.gameObject;

		if (parent.GetComponent<Grabable>() != null)
		{
			Debug.Log("is Grabed");
			return true;
		}
		else
		{
			Debug.Log("is not Grabed");
			return false;
		}
	}

	public bool ObstacleIsLeaveByItem(float leaveLen)
	{
		float _len = Vector3.Magnitude(this.gameObject.transform.position);

		if (_len > leaveLen)
		{
			Debug.Log("is Leave");
			return true;
		}
		else
		{
			Debug.Log("is not Leave");
			return false;
		}
	}
}