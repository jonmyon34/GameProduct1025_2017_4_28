using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	const int OBJ_MAX = 20;

	public ObstacleManager obstacleManager;
	public ItemManager itemManager;

	Vector3 _pos, _rota;

	public bool Obstacle_OFF = false;
	public bool Item_OFF = false;

	public void Init()
	{
		obstacleManager = this.gameObject.GetComponent<ObstacleManager>();
		itemManager = this.gameObject.GetComponent<ItemManager>();

		_pos = Vector3.zero;
		_rota = Vector3.zero;

		for (int i = 0; i < OBJ_MAX; i++)
		{
			if (!Obstacle_OFF)
				obstacleManager.Init(i, ref _pos, ref _rota);
			else
				RandPosRota();

			if (!Item_OFF)
				itemManager.Init(i, _pos, _rota);
		}
	}

	public void ManagedUpdate()
	{
		if (!Obstacle_OFF)
			obstacleManager.ManagedUpdate();

		if (!Item_OFF)
			itemManager.ManagedUpdate();
	}

	void RandPosRota()
	{
		const float POS_RANDVAL_ABS_MIN = 4.0f;
		const float POS_RANDVAL_ABS_MAX = 10.0f;

		while (true)
		{
			_pos.x = UnityEngine.Random.Range(-POS_RANDVAL_ABS_MAX, POS_RANDVAL_ABS_MAX);
			_pos.y = 0.0f;
			_pos.z = UnityEngine.Random.Range(-POS_RANDVAL_ABS_MAX, POS_RANDVAL_ABS_MAX);

			float len = Vector3.Magnitude(_pos);
			if (len > POS_RANDVAL_ABS_MIN)break;
		}

		_rota = Vector3.zero;
		_rota.y = UnityEngine.Random.Range(-180.0f, 180.0f);

	}
}