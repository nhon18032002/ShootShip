using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    protected float time = 0f;
    protected float mTime = 0.2f;
    public Transform holder;

    private void Awake()
    {
        this.LoadHolder();
    }
    void LoadHolder()
    {
        this.holder = transform.parent.Find("Holder");
    }
    // Update is called once per frame

    public void Spawn(Vector3 pos,Quaternion rota,int index)
    {
        //Quaternion newRota = Quaternion.AngleAxis(0, Vector3.forward);
        Transform newItem = ItemSpawner.instance.Spawn(pos,Quaternion.identity,index);
        newItem.SetParent(this.holder);
        newItem.gameObject.SetActive(true);
    }
}
