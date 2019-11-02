using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKey : MonoBehaviour
{
    public ItemEraser itemEraser;
    public ItemMover itemMover;

    public void Init()
    {
        itemEraser = this.gameObject.GetComponent<ItemEraser>();
        itemMover = this.gameObject.GetComponent<ItemMover>();
        itemEraser.Init();
        itemMover.Init();
    }

    public void ManagedUpdate()
    {
        itemEraser.ManagedUpdate();
        itemMover.ManagedUpdate();
    }
}
