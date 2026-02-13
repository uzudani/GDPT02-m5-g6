using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeleportRing", menuName = "Data/TeleportRing")]
public class SO_TeleportingRing : SO_Item
{
    public float chargeTime = 2f;

    public override void Use(GameObject player)
    {
        PlayerInventory.Instance.StartTeleport(player, chargeTime);
    }
}
