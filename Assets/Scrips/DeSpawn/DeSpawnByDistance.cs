using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByDistance : DeSpawn
{
    // Start is called before the first frame update
    protected Camera m_Camera;
    protected float distance=0f;
    protected float maxDistance = 40f;
    private void Awake()
    {
        this.loadCmr();
    }
    void loadCmr()
    {
        this.m_Camera = Transform.FindObjectOfType<Camera>();
    }
    protected override bool CanDeSpawn()
    {
        //throw new System.NotImplementedException();
        this.distance = Vector3.Distance(transform.position, this.m_Camera.transform.position);
        if (distance >= maxDistance) return true;
        return false;
    }

    protected override void DeSpawnObj()
    {
        Destroy(transform.parent.gameObject);
        //transform.gameObject.SetActive(false);
        //Spawner.instance.poolObj.Add(transform);
    }
}
