using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public PlayerImpact playerImpact;
    public FollowKeyboard followKeyboard;
    static public PlayerCtrl instance;
    public PlayerReceiveDamage playerReceiveDamage;

    protected virtual void LoadPlayerImpact()
    {
        this.playerImpact=Transform.FindObjectOfType<PlayerImpact>();
        this.playerReceiveDamage=GetComponentInChildren<PlayerReceiveDamage>(); 
    }
    protected void Reset()
    {
        this.Awake();
    }
    private void Awake()
    {
        this.LoadPlayerImpact();
        this.LoadKeyboard();
        PlayerCtrl.instance=this;
    }
    protected virtual void LoadKeyboard()
    {
        this.followKeyboard = Transform.FindObjectOfType<FollowKeyboard>();
    }
}
