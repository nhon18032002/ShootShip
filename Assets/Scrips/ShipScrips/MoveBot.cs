using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveBot : MoveObj
{

    [SerializeField] protected Transform player;
    protected float timeIdel=0;
    protected float timeIdelMax=5; public Vector3 newpos= new Vector3(0,0,0);
    bool test = true; float p1=0, p2=0, p3=0; int moveRd = 1;
    public Transform shipImage;
    protected ShipAttack shipAttack;
    private void Awake()
    {
        this.shipAttack=transform.parent.GetComponentInChildren<ShipAttack>();
        this.shipImage = transform.parent.Find("ShipImage");
        this.player = GameObject.Find("Player0").transform;
        }
    protected override void Move()
    {
        base.Move();
        if (Vector3.Distance(transform.parent.position, this.player.position) > 10) this.moveRd = 1;
        else if (Vector3.Distance(transform.parent.position, this.player.position) < 6) this.moveRd = Random.Range(2, 4);

        if (this.test)
        {
            this.moveRd = Random.Range(1, 4);
             //Debug.Log("rd: "+this.moveRd);
            this.test = false;
            
        }
        switch (this.moveRd)
            {
                case 1:
                    this.Move1();
                    this.shipAttack.isAttack = false;
                //ShipAttack.instance.isAttack = true;
                // this.test = false;
                    break;
                case 2:
                    this.Move2();
                    this.shipAttack.isAttack = true;
                this.shipAttack.mTime = 2.5f;
                //this.test = false;
                break;
                case 3:
                    this.Move3();
                    this.shipAttack.isAttack = true;
                    this.shipAttack.mTime = 1f;
                // this.test = false;
                    break;
          }
        
        this.timeIdel += Time.fixedDeltaTime;
        if (this.timeIdel < this.timeIdelMax) { return; }
        this.timeIdel = 0; this.test = true;
       
    }
    protected virtual void Move1()
    {
        this.speed = 5f;
        if (!(this.timeIdel == 0))
        {
            this.newpos = new Vector3(this.p2, this.p3, 0);
            
            Vector3 distance = this.newpos - transform.parent.position;
            float angle = Mathf.Atan2(distance.y, distance.x)*Mathf.Rad2Deg;
            this.shipImage.rotation = Quaternion.Euler(0,0,angle);
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, this.newpos, this.speed * Time.fixedDeltaTime);
        }
     
        if (!(transform.parent.position.x-p2<=0&& transform.parent.position.y - p3<=0 || this.timeIdel==0)) return;
        this.p1 = Random.Range(1, 5);
        //this.p2 = Random.value;
        if (Random.value > 0.4) this.p2 = this.player.position.x + this.p1; else this.p2 = this.player.position.x - this.p1;
        //Debug.Log(Random.value>0.5);
        this.p1 = Random.Range(1, 5);
       
        //this.p3 = Random.value;
        if (Random.value > 0.4) this.p3 = this.player.position.y + this.p1; else this.p3 = this.player.position.y - this.p1;
        
    }
    protected void Move2()
    {
        this.speed =5f;
        transform.parent.Translate(Vector3.right * this.speed * Time.fixedDeltaTime);
        //transform.parent.position = Vector3.Lerp(transform.parent.position, newpos, this.speed * Time.fixedDeltaTime);

        transform.parent.Rotate(Vector3.forward * 1f);
        Vector3 distance = this.player.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        this.shipImage.rotation = Quaternion.Euler(0, 0, angle);
    }
    protected void Move3()
    {
        this.speed = 5f;
        Vector3 distance = this.player.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        this.shipImage.rotation = Quaternion.Euler(0, 0, angle);
    }
}
