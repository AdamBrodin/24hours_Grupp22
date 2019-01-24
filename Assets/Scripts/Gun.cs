using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Gun", menuName = "Inventory/Gun", order = 1)]
public class Gun : ScriptableObject
{
    public float knockback;
    public float shakeduration;
    public float lifetime;
    public int damage;
    public float bulletspeed;
    public float firerate;
    public float spread;
}
