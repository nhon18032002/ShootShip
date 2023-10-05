using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventery : MonoBehaviour
{
    static public Inventery instance;
    //protected int MaxSlot=10;
    public Transform contentItems;
    public Transform itemInventory;
    [SerializeField] protected List<ItemInventery> items;
      
    public bool AddItem(ItemInventery itemInventery, int cout)
    {
        ItemInventery item = this.items.Find((it) => it.itemSO.id == itemInventery.itemSO.id);
        if (item == null)
        {
            itemInventery.cout = cout;

            Transform newItem = Instantiate(this.itemInventory, Vector3.zero, Quaternion.identity);
            newItem.gameObject.SetActive(true);
            Image image = newItem.GetComponentInChildren<Image>();
            image.sprite = itemInventery.itemSO.spriteItem;
            TextMeshProUGUI text = newItem.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText(itemInventery.cout.ToString());

            newItem.SetParent(this.contentItems);
            itemInventery.itemContent = newItem;
            this.items.Add(itemInventery);
            return true;
        }
        if (item.cout >= item.maxStack) return false;
        item.cout += cout;

        foreach (ItemInventery i in this.items)
        {
            if (i.itemSO.id == itemInventery.itemSO.id)
            {
                TextMeshProUGUI text = i.itemContent.GetComponentInChildren<TextMeshProUGUI>();
                text.SetText(item.cout.ToString());
            }
        }
        Debug.Log("Da Them");
        return true;
            
        
    }
    private void Awake()
    {
        Inventery.instance = this;
        this.itemInventory = transform.Find("ItemInventory");
    }
}
