using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : MonoBehaviour
{
    public Collider2D _collider2D;
    protected Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public PlayerCtrl playerCtrl;
    public PlayerReceiveDamage playerReceiveDamage;
    // Start is called before the first frame update
    private void Awake()
    {
        this.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        this.playerCtrl = Transform.FindObjectOfType<PlayerCtrl>(); 
    }
    protected void LoadComponent()
    {
        this._collider2D = GetComponent<Collider2D>();
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this.playerReceiveDamage = transform.parent.GetComponentInChildren<PlayerReceiveDamage>();
    }
    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    BGFollowPlayer bGFollowPlayer=collision.GetComponent<BGFollowPlayer>();
    //    if (bGFollowPlayer != null)
    //    { PlayerCtrl.instance.followKeyboard.bl=false; Debug.Log("true"); return; }
    //    PlayerCtrl.instance.followKeyboard.bl=true; Debug.Log("flase");
    //}
}
