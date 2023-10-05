using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Player",menuName ="SO/Player")]
public class PlayerSO : ScriptableObject
{
    public new string name = "Player";
    public float maxHp = 20;
    public float damage = 3;
}
