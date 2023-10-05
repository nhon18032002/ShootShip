using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
   
    public float bulletDamage;
    //public float BulletDamage=>bulletDamage;
    protected BulletSO bulletSO;
    private void Awake()
    {
        this.LoadBulletSO();
        this.CreateBullet();
    }
    protected virtual void LoadBulletSO()
    {
        this.bulletSO = Resources.Load<BulletSO>("Bullet/" + transform.parent.name.Replace("(Clone)",""));
    }
    protected virtual void CreateBullet()
    {

        this.bulletDamage = this.bulletSO.damage;
    }
    public virtual void SendDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.ReceiDamage(this.bulletDamage);
    }
    
}
