using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KeyItem", menuName = "Inventory/KeyItem")]
public class KeyItems : ScriptableObject
{
    public new string name = "new Item";

    public string type;

    public bool truth;

    public Sprite image = null;

}
