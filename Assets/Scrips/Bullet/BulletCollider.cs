using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : DeSpawn
{

    protected Collider2D _collider2D;
    protected Rigidbody2D _rigidbody2D;
    protected bool test=false;
    protected SpawnAniEx spawnAniEx;
    protected DamageSender damageSender;
    protected SpawnTextDamage spawnTextDamage;
    protected virtual void loadComponent()
    {
        this.spawnTextDamage=Transform.FindObjectOfType<SpawnTextDamage>();
        this._collider2D=GetComponent<Collider2D>();
        this._rigidbody2D=GetComponent<Rigidbody2D>();
        this.spawnAniEx = Transform.FindObjectOfType<SpawnAniEx>();
        this.damageSender=Transform.FindObjectOfType<DamageSender>();
    }
    private void Awake()
    {
        this.loadComponent();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log( " bullet layer " + gameObject.layer);
        if (collision.gameObject.layer == 1 && gameObject.layer == 2) return;
        ShapeImpact shapeImpact = collision.GetComponent<ShapeImpact>();
        if (shapeImpact != null)
        {
            this.spawnAniEx.Spawn(transform.parent.position, transform.parent.rotation, 1);
            this.damageSender.SendDamage(shapeImpact._receiver);
            this.test = true;
            this.spawnTextDamage.Spawn(shapeImpact.transform.position, Quaternion.identity, 0,this.damageSender.bulletDamage);
        }
        PlayerImpact playerImpact = collision.GetComponent<PlayerImpact>();
        if (playerImpact != null)
        {
            this.spawnAniEx.Spawn(transform.parent.position, transform.parent.rotation, 1);
            playerImpact.playerReceiveDamage.ReceiDamage(this.damageSender.bulletDamage);
           // Debug.Log("player hp:"+playerImpact.playerReceiveDamage.shipHp);
            
            this.spawnTextDamage.Spawn(playerImpact.transform.position, Quaternion.identity, 0, this.damageSender.bulletDamage);
            this.test = true;
        }
    }
    protected override bool CanDeSpawn()
    {
        if (this.test)
        {
            this.test = false;
            return !this.test;
        }
        return this.test;
    }
    protected override void DeSpawnObj()
    {
        base.DeSpawnObj();
        Destroy(transform.parent.gameObject);
    }
}
