using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Data/Potion")]
public class SO_HealthPotion : SO_Item
{
    public float healingPoints;
    public override void Use(GameObject player)
    {
        LifeController lifeController = player.GetComponent<LifeController>();
        if (lifeController != null)
        {
            lifeController.Heal(healingPoints);
            Debug.Log("Hai usato la pozione!");
        }
    }
}
