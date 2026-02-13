using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_Item : ScriptableObject
{
    public int Id;
    public Sprite Icon;
    public string Name;
    public string Description;

    public abstract void Use(GameObject player);
}
