using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun")]
public class Weapon : ScriptableObject
{
    public Bullet bullet;
    
    public new string name;
    public int priceInShop;
    public int damage;
    public int energyConsumption;
    public float fireRate;
    public float bulletSpeed;

    public AudioClip fireSound;
    
    public Sprite attachToBodySprite;
    public Sprite icon;
    
}
