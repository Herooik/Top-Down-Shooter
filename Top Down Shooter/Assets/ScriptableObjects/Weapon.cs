using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun")]
public class Weapon : ScriptableObject
{
    public int damage;
    public int ammo;
    public float fireRate;
    public float bulletSpeed;

    public Sprite attachToBody;
    public Sprite image;
}
