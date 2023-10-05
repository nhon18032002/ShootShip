using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveBullet : MoveObj
{
    // Start is called before the first frame update
    private void Awake()
    {
        this.speed = 15f;
    }
    protected override void Move()
    {
        
        base.Move();
        transform.parent.Translate(Vector3.right*Time.fixedDeltaTime*this.speed);
    }
    
}
