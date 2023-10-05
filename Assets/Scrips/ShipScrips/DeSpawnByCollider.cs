using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeSpawnByCollider : DeSpawn
{
   
   
    DamageReceiver damageReceiver;
    protected SpawnAniEx spawnAniEx;
    protected SpawnItem spawnItem;
    private void Awake()
    {
       this.spawnItem=Transform.FindObjectOfType<SpawnItem>();
        //this.damageReceiver = Transform.FindObjectOfType<DamageReceiver>();
        this.spawnAniEx = Transform.FindObjectOfType<SpawnAniEx>();
        this.damageReceiver = transform.parent.GetComponentInChildren<DamageReceiver>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player1") this.test = true;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Debug.Log("da va cham voi" + collision.name);
        //PlayerImpact playerImpact = collision.GetComponent<PlayerImpact>();
        //if (playerImpact == null) return;
        //this.test = true; 
        
    }
    // Start is called before the first frame update
    protected override bool CanDeSpawn()
    {
        // throw new System.NotImplementedException();
        //if (this.test)
        //{
        //    this.test = false;
        //    return true;
        //}

        //return false;
        return this.damageReceiver.isDeath();
    }
    protected override void DeSpawnObj()
    {
        AudioManager.instance.PlayAudio(1);
        this.spawnAniEx.Spawn(transform.parent.position, transform.parent.rotation,0);
        Destroy(transform.parent.gameObject);

        int index = this.damageReceiver.shipSO.itemSOs[0].id;//.Replace("Item", "");
        if (index < 0 || index > 2) return;
      

        
        //Debug.Log("index: "+index);
        int rate = Random.Range(0, 100000);
        if (rate <= this.damageReceiver.shipSO.itemSOs[0].dropRate) this.spawnItem.Spawn(transform.position, transform.rotation,index);
        //transform.gameObject.SetActive(false);
        //Spawner.instance.poolObj.Add(transform);
    }

    
}
