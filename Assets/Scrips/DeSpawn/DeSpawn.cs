using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeSpawn : MonoBehaviour
{

    // Start is called before the first frame update
   
    // Update is called once per frame
    private void FixedUpdate()
    {
        this.DeSpawning();
    }
    protected virtual void DeSpawning()
    {
        if (!this.CanDeSpawn()) return;
        this.DeSpawnObj();
    }
    protected virtual void DeSpawnObj()
    {
        //Destroy(transform.parent.gameObject);
        //transform.gameObject.SetActive(false);
        //Spawner.instance.poolObj.Add(transform);
    }
    protected abstract bool CanDeSpawn();
    
}
