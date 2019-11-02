using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public GameObject ObstaclePrefab;

	private Vector3 pos;
	private Vector3 rota;

	const float POS_RANDVAL_MIN = -5.0f;
	const float POS_RANDVAL_MAX = 5.0f;

	const float POS_RANDVAL_ABS_MIN = 4.0f;
	const float POS_RANDVAL_ABS_MAX = 10.0f;

	public void Init ()
	{
		ObstaclePrefab = (GameObject)Resources.Load ("Prefabs/Obstacle");
	}

	public void ManagedUpdate ()
	{

	}

	public GameObject ObstacleSpawn (out Vector3 _pos, out Vector3 _rota)
	{
		RandomPos ();
		RandomRota ();

		_pos = pos;
		_rota = rota;

		return Instantiate (ObstaclePrefab, pos, Quaternion.Euler (rota));
	}

	public Vector3 RandomPos ()
	{
		while (true)
		{
			pos.x = UnityEngine.Random.Range (-POS_RANDVAL_ABS_MAX, POS_RANDVAL_ABS_MAX);
			pos.z = UnityEngine.Random.Range (-POS_RANDVAL_ABS_MAX, POS_RANDVAL_ABS_MAX);

			float len = Vector3.Magnitude (pos);
			if (len > POS_RANDVAL_ABS_MIN)break;
		}
		return pos;
	}

	public Vector3 RandomRota ()
	{
		rota.y = UnityEngine.Random.Range (-180.0f, 180.0f);

		return rota;
	}

}