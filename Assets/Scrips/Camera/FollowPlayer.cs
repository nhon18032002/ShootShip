using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    protected float speed = 5f;
    static public FollowPlayer instance;
    public bool moving=true;
    protected new Camera camera;
    // Start is called before the first frame update
    private void Awake()
    {
        this.LoadPlayer();
        FollowPlayer.instance = this;
        this.camera=Camera.main;
        this.camera.orthographicSize = 1f;
    }
    protected virtual void LoadPlayer()
    {
        this.player = FindObjectOfType<PlayerCtrl>().transform;

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (this.CanMove()) this.Move();
        this.UpSizeCamera();

    }
    protected void UpSizeCamera()
    {
        if (this.camera.orthographicSize < 10) this.camera.orthographicSize += 0.1f;
    }

    protected void Move()
    {
        transform.position = Vector3.Lerp(transform.position, this.player.position, this.speed * Time.deltaTime);
        float camHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
        float camHalfHeight = Camera.main.orthographicSize;
        float leftLimit = GameObject.Find("BackGround").GetComponent<Renderer>().bounds.min.x + camHalfWidth;
        float rightLimit = GameObject.Find("BackGround").GetComponent<Renderer>().bounds.max.x - camHalfWidth;
        float bottomLimit = GameObject.Find("BackGround").GetComponent<Renderer>().bounds.min.y + camHalfHeight;
        float topLimit = GameObject.Find("BackGround").GetComponent<Renderer>().bounds.max.y - camHalfHeight;

        float clampedX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, topLimit);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }
    protected bool CanMove()
    {
        return this.moving;
    }
    //protected void OnTriggerExit2D(Collider2D collision)
    //{
    //    BGFollowPlayer bGFollowPlayer = collision.GetComponent<BGFollowPlayer>();
    //    if (bGFollowPlayer != null) { this.moving = false; return; }
    //    this.moving = true;

    //}
}
