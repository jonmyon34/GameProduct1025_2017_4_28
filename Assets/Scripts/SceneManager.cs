using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public PlayerManager plManager;
    public ObjectManager objectManager;

    public bool Player_OFF = false;
    public bool Object_OFF = false;

    void Start()
    {
        if (!Player_OFF)
            plManager.Init();

        if (!Object_OFF)
            objectManager.Init();
    }

    void Update()
    {
        if (!Player_OFF)
            plManager.ManagedUpdate();

        if (!Object_OFF)
            objectManager.ManagedUpdate();
    }
}