using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollowPlayer : MonoBehaviour
{
    public Collider2D _collider2D;
    public Transform player;
    protected float speed = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        this.LoadPlayer();
        this._collider2D = GetComponent<Collider2D>();
    }
    protected virtual void LoadPlayer()
    {
        this.player = GameObject.Find("Player0").transform;

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //if (Vector3.Distance(transform.position, this.player.position) > 9f)
        //    this.speed +=0.1f;
        //else this.speed -= 0.1f;
        //if (this.speed < 0.5f) this.speed = 0.5f;
        //transform.position =  Vector3.Lerp(transform.position, this.player.position, this.speed*Time.fixedDeltaTime);
    }
}
