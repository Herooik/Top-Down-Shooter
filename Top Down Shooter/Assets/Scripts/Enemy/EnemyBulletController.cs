using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Weapon _weapon;

    private void DealDamage(Collider2D target)
    {
        PlayerHealthSystem targetObject = target.gameObject.GetComponent<PlayerHealthSystem>();
        
        if (targetObject != null)
        {
            targetObject.TakeDamage(_weapon.damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var bulletEfect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(bulletEfect, 0.5f);
            Destroy(gameObject);
            DealDamage(other);
        }
        else
        {
            Destroy(gameObject, 5f);
        }
    } 
}
