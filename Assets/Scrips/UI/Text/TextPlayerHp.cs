using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPlayerHp : BaseText
{
    protected PlayerReceiveDamage playerReceiveDamage;
    protected override void LoadComponent()
    {
        base.LoadComponent();
       this.playerReceiveDamage = Transform.FindObjectOfType<PlayerReceiveDamage>();
    }
    private void FixedUpdate()
    {
        this.text.SetText(this.playerReceiveDamage.playerHp.ToString()+"/"+this.playerReceiveDamage.playerMaxHp.ToString()+"\nDamage: "+this.playerReceiveDamage.playerDamage.ToString());
    }
}
