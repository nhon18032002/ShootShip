using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextDamge : BaseText
{
    protected float curentScale=0;
    protected float MaxScale=0.025f;
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    private void FixedUpdate()
    {
        this.UpdateScale();

    }
    protected void UpdateScale()
    {
        if (this.curentScale >= this.MaxScale) return;
        this.curentScale += this.MaxScale / 10;
        transform.localScale = new Vector3(this.curentScale, this.curentScale,0);
    }
    public virtual void SetDamage(float damage)
    {
        this.text.SetText("- "+damage.ToString());
    }
 
}
