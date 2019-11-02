using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;

    const int OBSTACLE_MAX = 20;

    public GameObject[] obstacles = new GameObject[OBSTACLE_MAX];
    public Obstacle[] obstacleScripts = new Obstacle[OBSTACLE_MAX];

    public void Init(int i, ref Vector3 _pos, ref Vector3 _rota)
    {
        obstacleSpawner = this.gameObject.GetComponent<ObstacleSpawner>();
        obstacleSpawner.Init();

        Spawn(i, ref _pos, ref _rota);
    }

    public void ManagedUpdate()
    {
        for (int i = 0; i < OBSTACLE_MAX; i++)
        {
            if (obstacles[i] == null)continue;

            obstacleScripts[i].ManagedUpdate();
        }
    }

    void Spawn(int i, ref Vector3 _pos, ref Vector3 _rota)
    {
        obstacles[i] = obstacleSpawner.ObstacleSpawn(out _pos, out _rota);

        Debug.Log("Obstacle spawned");
        obstacleScripts[i] = obstacles[i].gameObject.GetComponent<Obstacle>();
        if (obstacleScripts[i] == null)Debug.Log("Obstacle null");

        obstacleScripts[i].Init();
    }

}