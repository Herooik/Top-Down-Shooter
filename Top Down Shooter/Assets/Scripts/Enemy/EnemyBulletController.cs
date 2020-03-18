using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private float weaponDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            weaponDamage = WeaponChange.instance._selectedWeapon.damage;
            
            ReferenceHolder.Instance.PlayerHealthSystem.TakeDamage(weaponDamage);
        }
    }
}