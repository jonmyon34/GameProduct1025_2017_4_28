using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player;

    public void Init()
    {
        player=this.gameObject.GetComponent<Player>();

        player.Init();
    } 

    public void ManagedUpdate()
    {
        player.ManagedUpdate();
    }
}
