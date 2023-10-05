using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeCtrl : MonoBehaviour
{
    public BulletCollider bulletCollider;
    public ShapeImpact shapeImpact;
    //static public PlayerCtrl instance;

    protected virtual void LoadPlayerImpact()
    {
        this.bulletCollider = Transform.FindObjectOfType<BulletCollider>();
    }
    protected void Reset()
    {
        this.Awake();
    }
    private void Awake()
    {
        this.LoadPlayerImpact();
        this.LoadKeyboard();
        //ShapeCtrl.instance=this;
    }
    protected virtual void LoadKeyboard()
    {
        this.shapeImpact = Transform.FindObjectOfType<ShapeImpact>();
    }
}
