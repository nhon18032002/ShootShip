using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    static public SpawnerBullet instance;
    [SerializeField] protected List<Transform> bullets;
    [SerializeField] public List<Transform> poolObj;
    // Start is called before the first frame update
    private void Awake()
    {
        SpawnerBullet.instance = this;
        LoadComponent();
        this.poolObj=new List<Transform>();
    }
    protected void LoadComponent()
    {
        foreach (Transform trf in transform)
        {
            if (trf.name == "Holder") return;
            this.bullets.Add(trf);
            trf.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    public virtual Transform Spawn(Vector3 pos,Quaternion rotation, int index)
    {
       // int value=Random.Range(0, bullets.Count);
        Transform trf = this.bullets[index];
        Transform newBullet = Instantiate(trf,pos,rotation);
        AudioManager.instance.PlayAudio(0);
        return newBullet;
    }
    public Transform GetTransform()
    {
        return transform.Find("Holder");
    }
}
