using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    // Start is called before the first frame update
    protected float time = 0f;
    protected float mTime = 0.2f;
    public Transform holder;
    protected bool test = true;
    private void Awake()
    {
        //LoadHolder();
    }
    void LoadHolder()
    {
        this.holder = transform.Find("Holder");
    
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {
       
        if (Input.GetMouseButton(0)) 
        {
            if (this.test)
            { this.Spawn(); this.test = false; }
        }
        if (this.test==false)
        {
            this.time += Time.fixedDeltaTime;
            if (this.time < this.mTime) return;
            this.time = 0f;
            this.test = true;
        }

    }
    protected void Spawn()
    {
        
        Vector3 distance =LoadInputMouse.instance.MousePosition- PlayerCtrl.instance.transform.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Quaternion newRota1= Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion newRota2= Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 sqvector = new Vector3(distance.y, - distance.x, 0).normalized;
        Transform newBullet1 = SpawnerBullet.instance.Spawn(transform.parent.position+distance.normalized*0.85f,newRota1,0);
        Transform newBullet2 = SpawnerBullet.instance.Spawn(transform.parent.position + distance.normalized*0.85f , newRota2,0);
        //newShape.transform.parent = gameObject.transform.Find("Holder");
        newBullet1.position+=sqvector/4;
        newBullet2.position -= sqvector/4;
        newBullet1.SetParent(this.holder);
        newBullet1.gameObject.SetActive(true);
        newBullet2.SetParent(this.holder);
        newBullet2.gameObject.SetActive(true);
        MoveBullet move=newBullet1.GetComponentInChildren<MoveBullet>();
        move.speed = 30;
        move = newBullet2.GetComponentInChildren<MoveBullet>();
        move.speed = 30;
        this.setDamagePlayer(newBullet1);
        this.setDamagePlayer(newBullet2);
    }
    protected void setDamagePlayer(Transform transForm)
    {
        DamageSender damage = transForm.GetComponentInChildren<DamageSender>();
        PlayerReceiveDamage playerDamage = transform.parent.GetComponentInChildren<PlayerReceiveDamage>();
        damage.bulletDamage = playerDamage.playerDamage;
    }
}
