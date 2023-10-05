using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Ship",menuName ="SO/Ship")]
public class ShipSO : ScriptableObject
{
    public string ShipName = "Ship1";
    public int hp = 10;
    public int maxhp = 10;
    public List<ItemSO> itemSOs;
}
