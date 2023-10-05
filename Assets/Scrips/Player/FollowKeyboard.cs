using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKeyboard : MoveObj
{
    public PlayerCtrl playerCtrl;
    public Transform Model;
    public bool bl=false;
    public PlayerImpact playerImpact;
    public BGFollowPlayer bGFollowPlayer;
    public ClonePlayer clonePlayer;
    public float maxPos = 1f;
    public float pos = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        this.speed = 10f;
        this.bGFollowPlayer = Transform.FindObjectOfType<BGFollowPlayer>();
        this.playerImpact=transform.parent.GetComponentInChildren<PlayerImpact>();
        this.clonePlayer= transform.parent.GetComponentInChildren<ClonePlayer>();
        this.Model = transform.parent.Find("PlayerImage");
        this.LoadPlayerCtrl();
    }
    protected void Reset()
    {
        this.Awake();
    }
   
    protected virtual void LoadPlayerCtrl()
    {
        this.playerCtrl = Transform.FindObjectOfType<PlayerCtrl>();
    }
    // Update is called once per fra
    public bool IsMoving()
    {
        return !this.bl;
    }
    protected override void Move()
    {
        base.Move();
        Vector3 movement = LoadInputKeyboard.instance.keyboardPos;
        //Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        Vector3 newPos = transform.position + LoadInputKeyboard.instance.keyboardPos;
        
        transform.parent.Translate(movement * this.speed * Time.fixedDeltaTime);
      
     
        

     
        float halfWidth = transform.parent.localScale.x / 2f+1; 
        float halfHeight = transform.parent.localScale.y / 2f+1;
        float leftLimit = bGFollowPlayer._collider2D.bounds.min.x + halfWidth; 
        float rightLimit = bGFollowPlayer._collider2D.bounds.max.x - halfWidth;
        float bottomLimit = bGFollowPlayer._collider2D.bounds.min.y + halfHeight;
        float topLimit = bGFollowPlayer._collider2D.bounds.max.y - halfHeight;

        float clampedX = Mathf.Clamp(transform.parent.position.x, leftLimit, rightLimit); 
        float clampedY = Mathf.Clamp(transform.parent.position.y, bottomLimit, topLimit);


        transform.parent.position = new Vector3(clampedX, clampedY, 0f);
        Vector3 distance = movement * 3;
        if (movement.x == 0 && movement.y == 0 || Input.GetMouseButton(0)) return;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        this.Model.rotation = Quaternion.Euler(0, 0, angle - 90);
        //transform.parent.Translate(new Vector3(clampedX, clampedY, 0f) * this.speed * Time.fixedDeltaTime);
    }
}
