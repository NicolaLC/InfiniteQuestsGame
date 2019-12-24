using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : MonoBehaviour
{
  [SerializeField]
  public int damagePoints = 10;
  [SerializeField]
  public int heavyDamagePoints = 20;

  [HideInInspector]
  public int currentDamagePoints = 10;

  void Awake()
  {
    currentDamagePoints = damagePoints;
  }
}
