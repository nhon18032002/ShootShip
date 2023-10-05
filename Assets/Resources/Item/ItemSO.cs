
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Item",menuName ="SO/Item")]
public class ItemSO : ScriptableObject
{
    public new string name;
    public int id;
    public float dropRate=100000;
    public Sprite spriteItem;
}
