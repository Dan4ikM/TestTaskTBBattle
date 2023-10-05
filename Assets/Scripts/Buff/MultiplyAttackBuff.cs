using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyAttackBuff : Buff
{
    [SerializeField] private int multiplier; 
    
    public int ApplyBuff() => multiplier;
}
