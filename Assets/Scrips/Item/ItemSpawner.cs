using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    static public ItemSpawner instance;
    [SerializeField] protected List<Transform> Items;
    [SerializeField] public List<Transform> poolObj;
    protected Transform prefab;
    // Start is called before the first frame update
    private void Awake()
    {
        ItemSpawner.instance = this;
        LoadPrefab();
        LoadComponent();
       
        this.poolObj = new List<Transform>();
    }
    protected virtual void LoadPrefab()
    {
        this.prefab=transform.Find("Prefab");
    }
   
    protected void LoadComponent()
    {
        foreach (Transform trf in this.prefab)
        {
            //if (trf.name == "Holder") return;
            this.Items.Add(trf);
            trf.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    public virtual Transform Spawn(Vector3 pos, Quaternion rotation, int index)
    {
        // int value=Random.Range(0, bullets.Count);
        Transform trf = this.Items[index];
        Transform newItem = Instantiate(trf, pos, rotation);
        return newItem;
    }
}
