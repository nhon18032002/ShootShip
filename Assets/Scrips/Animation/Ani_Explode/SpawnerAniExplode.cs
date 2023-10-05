using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAniExplode : MonoBehaviour
{
    static public SpawnerAniExplode instance;
    [SerializeField] protected List<Transform> list;
    [SerializeField] public List<Transform> poolObj;
    // Start is called before the first frame update
    private void Awake()
    {
        SpawnerAniExplode.instance = this;
        LoadComponent();
        this.poolObj = new List<Transform>();
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
    // Start is called before the first frame update

    public Transform Spawn(Vector3 pos,Quaternion rotation,int index)
    {
        Transform trf = this.list[index];
        Transform newObj = Instantiate(trf,pos,rotation);
        //Vector3 p=new Vector3(0,0,-3);
        //newObj.position+=p;
        return newObj;
    }
}
