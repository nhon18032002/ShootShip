using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAniEx : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform holder;
    
    private void Awake()
    {
        LoadHolder();
       
    }
    void LoadHolder()
    {
        this.holder = transform.Find("Holder");
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {
        //if (true) Spawn();

    }
    public void Spawn(Vector3 pos, Quaternion rota,int index)
    {
      

        Transform newAni = SpawnerAniExplode.instance.Spawn(pos,rota,index);
        
        newAni.SetParent(this.holder);
        newAni.gameObject.SetActive(true);
    }
}
