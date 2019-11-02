using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	const int OBJ_MAX = 20;
	

	public ObstacleManager obstacleManager;
	public ItemManager itemManager;

	Vector3 _pos, _rota;

	public void Init()
	{
		obstacleManager = this.gameObject.GetComponent<ObstacleManager>();
		itemManager = this.gameObject.GetComponent<ItemManager>();


		_pos = Vector3.zero;
		_rota = Vector3.zero;

		for (int i = 0; i < OBJ_MAX; i++)
		{
			obstacleManager.Init(i, ref _pos, ref _rota);
			itemManager.Init(i, _pos, _rota);
		}
	}

	public void ManagedUpdate()
	{
		obstacleManager.ManagedUpdate();
		itemManager.ManagedUpdate();
	}
}