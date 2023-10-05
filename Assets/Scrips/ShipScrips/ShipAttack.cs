using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : MonoBehaviour
{
    public Transform holder;
    public Transform player;
    protected float time = 0f;
    public float mTime = 2f;
    
    public bool isAttack = false;
    protected int bullet0=0;
    private void Awake()
    {
       
        this.player = GameObject.Find("Player0").transform;
        //this.holder = SpawnerBullet.instance.GetTransform();
    }
    private void Start()
    {
        this.holder = SpawnerBullet.instance.GetTransform();
        this.bullet0=Random.Range(0, 4);
    }
    private void FixedUpdate()
    {
        if (this.isAttack)
        {
            this.time += Time.fixedDeltaTime;
            if (this.time < this.mTime) return;
            this.time = 0;
            this.AttackPlayer();
        }
    }
    protected virtual void AttackPlayer()
    {
        Vector3 distance = this.player.position - transform.parent.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Quaternion newRota1 = Quaternion.AngleAxis(angle, Vector3.forward);
        Transform newBullet1 = SpawnerBullet.instance.Spawn(transform.parent.position + distance.normalized * 2f, newRota1,this.bullet0);
        GameObject layerGame = newBullet1.transform.Find("BulletCollider").gameObject;
        layerGame.layer = 2;
        newBullet1.SetParent(this.holder);
        newBullet1.gameObject.SetActive(true);
    }
}
