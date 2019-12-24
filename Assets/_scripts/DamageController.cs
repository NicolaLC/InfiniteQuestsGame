using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
  [SerializeField]
  private float health = 100;
  private float _currentHealth;
  [SerializeField]
  private SpriteRenderer healthBarForeground;

  [SerializeField]
  private Animator animator;

  private bool invulnerable = false;

  void Awake()
  {
    _currentHealth = health;
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (invulnerable)
    {
      return;
    }
    if (col.gameObject.tag == "DamageZone")
    {
      DamageItem item = col.gameObject.GetComponent<DamageItem>();
      if (healthBarForeground)
      {
        _currentHealth -= item.currentDamagePoints;
        if (_currentHealth <= 0)
        {
          GameObject.Destroy(transform.parent.gameObject);
        }
        else
        {
          if (animator)
          {
            animator.SetTrigger("damaged");
          }
          Vector3 lScale = healthBarForeground.transform.localScale;
          lScale.x = _currentHealth / health;
          healthBarForeground.transform.localScale = lScale;
          Invoke("ResetInvulnerable", 0.5f);
        }
      }
    }
  }

  void ResetInvulnerable()
  {
    this.invulnerable = false;
  }
}
