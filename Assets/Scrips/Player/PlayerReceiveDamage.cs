using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiveDamage : MonoBehaviour
{
    public float playerHp;
    public float playerMaxHp;
    public PlayerSO playerSO;
    public float playerDamage;
    protected BnMenu bnMenu;
    protected UIGameOver UIGameOver;
    private void Awake()
    {
        this.LoadShipSO();
        this.CreateShip();
    }
    protected virtual void LoadShipSO()
    {
        this.playerSO = Resources.Load<PlayerSO>("Player/"+transform.parent.name);
        this.bnMenu=Transform.FindObjectOfType<BnMenu>();
        this.UIGameOver=Transform.FindObjectOfType<UIGameOver>();
    }
    protected virtual void CreateShip()
    {
        this.playerMaxHp = this.playerSO.maxHp;
        this.playerHp = this.playerMaxHp;
        this.playerDamage = this.playerSO.damage;
        
    }
    public virtual void ReceiDamage(float damage)
    {
        this.playerHp -= damage;
        if (this.playerHp < 0) this.playerHp = 0;
    }
    public virtual bool isDeath()
    {
        return this.playerHp <= 0;
    }
    protected void upDateDamage(float newDamage)
    {
        this.playerDamage = newDamage;
    }
    protected void FixedUpdate()
    {
        if (this.isDeath())
        {
            this.bnMenu.Active();
            this.UIGameOver.gameObject.SetActive(true);
            Transform ani = SpawnerAniExplode.instance.Spawn(transform.position, Quaternion.identity, 0);
            ani.gameObject.SetActive(true);
            transform.parent.gameObject.SetActive(false);
            
        }
    }
    public void IncreaseHp(int hp)
    {
        this.playerHp += hp;
        if (this.playerHp >= this.playerMaxHp) this.playerHp = this.playerMaxHp;
    }
}
