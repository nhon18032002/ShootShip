using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextSpawner : MonoBehaviour
{
    static public DamageTextSpawner instance;
    [SerializeField] protected List<Transform> tests;
    [SerializeField] public List<Transform> poolObj;
    protected Transform prefab;
    // Start is called before the first frame update
    private void Awake()
    {
        DamageTextSpawner.instance = this;
        LoadPrefab();
       

        this.poolObj = new List<Transform>();
    }
    private void Start()
    {
        LoadComponent();
    }
    protected virtual void LoadPrefab()
    {
        this.prefab = transform.Find("Prefab");
    }

    protected void LoadComponent()
    {
        foreach (Transform trf in this.prefab)
        {
            //if (trf.name == "Holder") return;
            this.tests.Add(trf);
            trf.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    public virtual Transform Spawn(Vector3 pos, Quaternion rotation, int index, float damage)
    {
        // int value=Random.Range(0, bullets.Count);
        Transform trf = this.tests[index];
        TextDamge tD = trf.GetComponentInChildren<TextDamge>();
        tD.SetDamage(damage);
        Transform newItem = Instantiate(trf, pos, rotation);
        return newItem;
    }
}
