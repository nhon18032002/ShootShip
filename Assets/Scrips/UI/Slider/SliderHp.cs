using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHp : BaseSlider
{
    protected DamageReceiver damageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.damageReceiver = transform.parent.parent.GetComponentInChildren<DamageReceiver>();
    }
    protected override void OnChanged(float hp)
    {
        
    }
    private void FixedUpdate()
    {
        this.slider.value = this.damageReceiver.ShipHp / this.damageReceiver.ShipMaxHp;
    }
}
