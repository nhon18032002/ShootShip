using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMousePos : MoveObj
{
    public Transform Model;
    private void Awake()
    {
        
        this.speed = 2f;
    }

    protected override void Move()
    {
        if (!this.OnMouseDown()) return;
        base.Move();

        this.newPos = LoadInputMouse.instance.MousePosition;
        //this.newPos.z = 0;
        //if (Vector3.Distance(transform.position, this.newPos) < 0.2f) return;
        //transform.parent.position = Vector3.Lerp(transform.parent.position, newPos, speed * Time.fixedDeltaTime);
        //float angle = Vector3.Angle(this.newPos,transform.position);
        //transform.parent.rotation=Quaternion.Euler(0,0,angle);
        Vector3 distance = this.newPos - transform.parent.position;
        float angle = Mathf.Atan2(distance.y,distance.x) * Mathf.Rad2Deg;
        //transform.parent.rotation = Quaternion.Euler(0, 0, angle);
        this.Model.rotation = Quaternion.Euler(0, 0, angle - 90);

    }
    protected virtual bool OnMouseDown()
    {
        if (Input.GetMouseButton(0)) return true;
        return false;

    }
}
