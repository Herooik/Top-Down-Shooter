using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun")]
public class Weapon : ScriptableObject
{
    public int damage;
    public int ammoConsumption;
    public float fireRate;
    public float bulletSpeed;

    public Sprite attachToBodySprite;
    public Sprite image;
}
