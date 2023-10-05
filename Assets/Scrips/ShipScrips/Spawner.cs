using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static public Spawner instance;
    [SerializeField] protected List<Transform> list;
    [SerializeField] public List<Transform> poolObj;
    // Start is called before the first frame update
    private void Awake()
    {
        Spawner.instance = this;
        LoadComponent();
        this.poolObj=new List<Transform>();
    }
    protected void LoadComponent()
    {
        foreach (Transform trf in transform)
        {
            if (trf.name == "Holder") return;
            this.list.Add(trf);
            trf.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    public virtual Transform Spawn(Vector3 pos,Quaternion rotation)
    {
        int value=Random.Range(0, list.Count);
        Transform trf = this.list[value];
        Transform newObj = Instantiate(trf,pos,rotation);
        
        return newObj;
    }
}
