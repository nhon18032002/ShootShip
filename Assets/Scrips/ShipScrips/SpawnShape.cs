using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShape : MonoBehaviour
{
    // Start is called before the first frame update
    protected float time=0;
    public float maxTime = 3f;
    protected float value = 0;
    protected Transform holder;
    protected float ps = 15f;
    public bool isSpawn = true;
    private void Awake()
    {
        this.LoadHolder();
       
    }
    private void Start()
    {
        this.SpawnBot();
    }
    void LoadHolder()
    {
        this.holder = transform.Find("Holder");
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (!this.isSpawn) return;
        this.time += Time.fixedDeltaTime;
        if (this.time < this.maxTime) return;
        this.time = 0;
        //this.time = 0;this.value += 1;
        //if (this.value%3==0 &&this.maxTime>1)
        //{ this.maxTime-=0.2f; this.value *= 3f; }
        int rd = Random.Range(1, 4);
        switch (rd)
        {
            case 1:
                SpawnBot();
                break;
            case 2:
                SpawnRight();
                break;
            case 3:
                SpawnLeft();
                break;
            case 4:
                SpawnTop();
                break;
        }
    }
    protected void Spawn(Vector3 pos, Quaternion rotation)
    {
        

        Transform newShape = Spawner.instance.Spawn(pos, rotation);
        //newShape.transform.parent = gameObject.transform.Find("Holder");
        newShape.SetParent(this.holder);
        newShape.gameObject.SetActive(true);
    }
    protected void SpawnTop()
    {
        
        float pos = Random.Range(FollowPlayer.instance.transform.position.x - this.ps, FollowPlayer.instance.transform.position.x+ this.ps);
        Vector3 newPos = new Vector3(pos, FollowPlayer.instance.transform.position.y+ this.ps, 0);
        Quaternion rota = Quaternion.AngleAxis(-90, Vector3.forward);
        this.Spawn(newPos, rota);
        //if (Spawner.instance.poolObj.Count > 0)
        //{
        //    foreach (Transform child in holder)
        //    {
        //        if (child.gameObject.active == false && child.name == Spawner.instance.poolObj[0].name)
        //        {
        //            child.gameObject.SetActive(true);
        //            child.gameObject.transform.position = newPos;
        //            Spawner.instance.poolObj.RemoveAt(0);
        //            return;
        //        }
        //    }

        //}    
    }
    protected void SpawnLeft()
    {

        float pos = Random.Range(FollowPlayer.instance.transform.position.y- this.ps, FollowPlayer.instance.transform.position.y+ this.ps);
        Vector3 newPos = new Vector3(FollowPlayer.instance.transform.position.x - this.ps, pos, 0);
        Quaternion rota = Quaternion.AngleAxis(0, Vector3.forward);
        this.Spawn(newPos, rota);
    }
    protected void SpawnRight()
    {

        float pos = Random.Range(FollowPlayer.instance.transform.position.y - this.ps, FollowPlayer.instance.transform.position.y+ this.ps);
        Vector3 newPos = new Vector3(FollowPlayer.instance.transform.position.x+ this.ps, pos, 0);
        Quaternion rota = Quaternion.AngleAxis(180, Vector3.forward);
        this.Spawn(newPos, rota);
        
    }
    protected void SpawnBot()
    {

        float pos = Random.Range(FollowPlayer.instance.transform.position.x - this.ps, FollowPlayer.instance.transform.position.x+ this.ps);
        Vector3 newPos = new Vector3(pos, FollowPlayer.instance.transform.position.y- this.ps, 0);
        Quaternion rota = Quaternion.AngleAxis(90, Vector3.forward);
        this.Spawn(newPos, rota);
    }
}
