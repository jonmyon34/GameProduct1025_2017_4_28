﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemSpawner itemSpawner;

    const int ITEM_MAX = 20;

    public GameObject[] items = new GameObject[ITEM_MAX];
    public Item[] itemScripts = new Item[ITEM_MAX];

    private int keyCount = 0;
    private int noisyCount = 0;
    private int garbageCount = 0;

    const int KEY_MAX = 1;
    const int NOISY_MAX = 3;
    const int GARBAGE_MAX = ITEM_MAX - (KEY_MAX + NOISY_MAX);

    enum STATE : int
    {
        KEY = 0,
        NOISY = 1,
        GARBAGE = 2,
    }

    public void Init()
    {
        itemSpawner = this.gameObject.GetComponent<ItemSpawner>();
        itemSpawner.Init();

        keyCount = 0;
        noisyCount = 0;
        garbageCount = 0;

        Spawn();
    }

    public void Init(int i, Vector3 _pos, Vector3 _rota)
    {
        itemSpawner = this.gameObject.GetComponent<ItemSpawner>();
        itemSpawner.Init();

        Spawn(i, _pos, _rota);
    }

    public void ManagedUpdate()
    {
        for (int i = 0; i < ITEM_MAX; i++)
        {
            if (items[i] == null)continue;

            itemScripts[i].ManagedUpdate();
        }
    }

    void Spawn(int i, Vector3 _pos, Vector3 _rota)
    {
        int type = TypeDecider();

        items[i] = itemSpawner.ItemSpawn(type, _pos, _rota);
        Debug.Log("Item spawned");

        itemScripts[i] = items[i].gameObject.GetComponent<Item>();
        itemScripts[i].Init(type);
    }

    void Spawn()
    {
        for (int i = 0; i < ITEM_MAX; i++)
        {
            //if (items[i] != null)continue;

            int type = TypeDecider();

            items[i] = itemSpawner.ItemSpawn(type);
            Debug.Log("Item spawned");

            itemScripts[i] = items[i].gameObject.GetComponent<Item>();
            itemScripts[i].Init(type);
        }
    }

    int TypeDecider()
    {
        int r;

        if (keyCount < KEY_MAX)
        {
            r = (int)STATE.KEY;
            keyCount++;
        }
        else if (noisyCount < NOISY_MAX)
        {
            r = (int)STATE.NOISY;
            noisyCount++;
        }
        else
        {
            r = (int)STATE.GARBAGE;
            garbageCount++;
        }

        return r;
    }

    int RandomPosDecider()
    {
        int r;
        while (true)
        {
            r = Random.Range(0, ITEM_MAX);

            if (items[r] == null)
                break;
        }

        return r;
    }
}