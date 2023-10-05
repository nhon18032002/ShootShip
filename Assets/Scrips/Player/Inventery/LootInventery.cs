using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class LootInventery : MonoBehaviour
{
    public Transform contentItems;
    public Transform itemInventory;
    [SerializeField] protected List<ItemInventery> items;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        ItemImpact itemImpact = collision.GetComponent<ItemImpact>();
        
        if (itemImpact == null) return;
        // Debug.Log(collision.transform.parent.name);
        ItemInventery itemInventery = new ItemInventery
        {
            itemSO = itemImpact.itemInfor.itemSO,
            itemContent = null,
            cout =0,
            maxStack=10
        };
        if(itemInventery==null) return;
        //if (Inventery.instance.AddItem(/*itemInventery, 1*/))
        {
            ItemInventery item = this.items.Find((it) => it.itemSO.id == itemInventery.itemSO.id);
            if (item == null)
            {
                itemInventery.cout = 1;
                Transform newItem = Instantiate(this.itemInventory, Vector3.zero, Quaternion.identity);
                newItem.gameObject.SetActive(true);
                newItem.SetParent(this.contentItems);
                Image image = newItem.GetComponentInChildren<Image>();
                image.sprite = itemInventery.itemSO.spriteItem;
                TextMeshProUGUI text = newItem.GetComponentInChildren<TextMeshProUGUI>();
                text.SetText(itemInventery.cout.ToString());
                itemInventery.itemContent = newItem;
                this.items.Add(itemInventery);
                Destroy(collision.transform.parent.gameObject);
                return;
            }
            if (item.cout >= item.maxStack)
            {
                //Destroy(collision.transform.parent.gameObject);
                return;
            }
                item.cout += 1;

                foreach (ItemInventery i in this.items)
                {
                    if (i.itemSO.id == itemInventery.itemSO.id)
                    {
                        TextMeshProUGUI text2 = i.itemContent.GetComponentInChildren<TextMeshProUGUI>();
                        text2.SetText(item.cout.ToString());
                    }
                }
            
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
