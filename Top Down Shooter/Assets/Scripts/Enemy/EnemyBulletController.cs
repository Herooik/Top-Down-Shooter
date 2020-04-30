using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private float _weaponDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();
        
        if (player != null)
        {
            gameObject.SetActive(false);

            _weaponDamage = WeaponChange.Instance.SelectedWeapon.damage;
            
            ReferenceContainer.Instance.playerHealthSystem.TakeDamage(_weaponDamage);
        }
    }
}