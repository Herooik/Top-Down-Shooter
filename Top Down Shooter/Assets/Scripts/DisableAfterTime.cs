using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;
    [SerializeField] private SpriteRenderer spriteRender;

    private void OnEnable()
    {
        StartCoroutine(Destroy(gameObject, lifeTime));
    }
    
    IEnumerator Destroy(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    private void OnDisable()
    {
        if (spriteRender != null)
        {
            spriteRender.sprite = WeaponChange.Instance.currentBulletSprite;
        }
    }
}
