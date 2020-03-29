using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private float _weaponDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            _weaponDamage = WeaponChange.instance._selectedWeapon.damage;
            
            ReferenceHolder.Instance.PlayerHealthSystem.TakeDamage(_weaponDamage);
        }
    }
}