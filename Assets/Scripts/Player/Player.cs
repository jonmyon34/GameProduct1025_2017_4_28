using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMover plMover;
    public PlayerHealthManager plHealthManager;
    public PlayerLightUser plLightUser ;
    public PlayerPickUper plPickUper ;

    public void Init ()
    {
        plMover = this.gameObject.GetComponent<PlayerMover>();
        plHealthManager = this.gameObject.GetComponent<PlayerHealthManager> ();
        plLightUser = this.gameObject.GetComponent<PlayerLightUser> ();
        plPickUper = this.gameObject.GetComponent<PlayerPickUper> ();

        plMover.Init();
        plHealthManager.Init();
        plLightUser.Init();
        plPickUper.Init();
    }

    public void ManagedUpdate()
    {
        plMover.ManagedUpdate();
        plHealthManager.ManagedUpdate();
        plLightUser.ManagedUpdate();
        plPickUper.ManagedUpdate();
    }
}