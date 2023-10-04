using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnSystem : MonoBehaviour
{
    public event EventHandler OnTurnChanged;

    private Unit currentUnit;
    
    private int turn_number = 0;
    
    public int GetRoundNumber() => (turn_number-1)/2 + 1;

    public void NewTurn(Unit unit)
    {
        turn_number++;
        currentUnit = unit;
    }

    private void AttackSystem_OnAttackEnded()
    {
        if (turn_number % 2 == 1) RoundEnd();
    }
    
    private void RoundEnd()
    {
        turn_number++;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }
}
