using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
  [SerializeField]
  private DamageItem damageItem;
  private Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetKey(KeyCode.LeftShift))
    {
      animator.SetBool("running", true);
    }
    else
    {
      animator.SetBool("running", false);
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
    {
      animator.SetBool("walking", true);
    }
    else
    {
      animator.SetBool("walking", false);
    }

    if (Input.GetMouseButtonDown(0))
    {
      damageItem.currentDamagePoints = damageItem.damagePoints;
      animator.SetTrigger("attack");
      animator.ResetTrigger("heavyAttack");
    }

    if (Input.GetMouseButtonDown(1))
    {
      damageItem.currentDamagePoints = damageItem.heavyDamagePoints;
      animator.ResetTrigger("attack");
      animator.SetTrigger("heavyAttack");
    }
  }
}
