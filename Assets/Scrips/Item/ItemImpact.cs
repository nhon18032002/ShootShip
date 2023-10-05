using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemImpact : MonoBehaviour
{
    protected new Rigidbody2D rigidbody2D;
    protected new Collider2D collider2D;
    public ItemInfor itemInfor;
    protected void LoadComponent()
    {
        this.rigidbody2D = transform.GetComponent<Rigidbody2D>();
        this.rigidbody2D.gravityScale = 0;
        
        this.collider2D = transform.GetComponent<Collider2D>();
        this.collider2D.isTrigger = true;
        this.itemInfor=transform.parent.GetComponentInChildren<ItemInfor>();
        //this.itemInfor=Transform.FindObjectOfType<ItemInfor>();
    }
    private void Awake()
    {
        this.LoadComponent();
    }
}
