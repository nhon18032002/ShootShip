using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTextDamage : MonoBehaviour
{
    protected float time = 0f;
    protected float mTime = 0.2f;
    public Transform holder;

    private void Awake()
    {
        this.LoadHolder();
    }
    void LoadHolder()
    {
        this.holder = transform.parent.Find("Holder");
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {

    }
    public void Spawn(Vector3 pos, Quaternion rota, int index,float damage)
    {
        
        Transform newItem = DamageTextSpawner.instance.Spawn(pos, Quaternion.identity, index,damage);
        newItem.SetParent(this.holder);
        newItem.gameObject.SetActive(true);
    }
}
