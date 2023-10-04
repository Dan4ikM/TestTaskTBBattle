using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class AttackSystem
{
    public static Action OnAttackEnded;
    
    private static int damage = 15;

    public static void Attack(Unit attacking_unit, Unit defending_unit)
    {
        defending_unit.ApplyDamage(damage);
        OnAttackEnded?.Invoke();
    }
}
