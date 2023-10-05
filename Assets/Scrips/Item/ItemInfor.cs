using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfor : MonoBehaviour
{
    public ItemSO itemSO;
    protected int id;
    protected new string name;
    protected float dropRate;
    protected Sprite spriteItem;
    private void Awake()
    {
        this.LoadItemSO();
        this.LoadInfor();
    }
    protected virtual void LoadItemSO()
    {
        this.itemSO = Resources.Load<ItemSO>("Item/"+ transform.parent.name.Replace("(Clone)",""));
    }
    protected virtual void LoadInfor()
    {
        this.name=this.itemSO.name;
        this.dropRate=this.itemSO.dropRate;
        this.id = this.itemSO.id;
        this.spriteItem=this.itemSO.spriteItem;
    }
}
