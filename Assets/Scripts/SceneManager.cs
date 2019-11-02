using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public PlayerManager plManager;
    public ObjectManager objectManager;

    void Start()
    {
        plManager.Init();
        objectManager.Init();
    }

    void Update()
    {
        plManager.ManagedUpdate();
        objectManager.ManagedUpdate();   
    }
}
