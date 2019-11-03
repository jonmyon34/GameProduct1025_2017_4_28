using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleEraser obstacleEraser;
    public ObstacleMover obstacleMover;

    public void Init()
    {
        obstacleEraser = this.gameObject.GetComponent<ObstacleEraser>();
        obstacleMover = this.gameObject.GetComponent<ObstacleMover>();
        obstacleEraser.Init();
        obstacleMover.Init();
    }

    public void ManagedUpdate()
    {
        obstacleEraser.ManagedUpdate();
        obstacleMover.ManagedUpdate();
    }
}
