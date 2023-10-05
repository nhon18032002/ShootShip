using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    public float ShipHp;
    public float ShipMaxHp;
    public ShipSO shipSO;
    private void Awake()
    {
        this.LoadShipSO();
        this.CreateShip();
    }
    protected virtual void LoadShipSO()
    {
        this.shipSO = Resources.Load<ShipSO>("Ship/"+transform.parent.name.Replace("(Clone)", ""));
    }
    protected virtual void CreateShip()
    {
        this.ShipMaxHp = this.shipSO.maxhp;
        this.ShipHp = this.ShipMaxHp;
    }
    public virtual void ReceiDamage(float damage)
    {
        this.ShipHp-=damage;
        if(this.ShipHp < 0) this.ShipHp = 0;
    }
    public virtual bool isDeath()
    {
        return this.ShipHp <= 0;
    }
}
