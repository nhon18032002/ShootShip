using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : DeSpawn
{
    protected float time = 0f;
    protected float mTime = 0.5f;
    // Start is called before the first frame update
    protected override bool CanDeSpawn()
    {
        this.time+=Time.fixedDeltaTime;
        if (this.time < this.mTime) return false;
        this.time = 0f; return true;
    }
    protected override void DeSpawnObj()
    {
        base.DeSpawnObj();
        Destroy(transform.parent.gameObject);
    }
}
