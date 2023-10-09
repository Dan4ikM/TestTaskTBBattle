using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Battle : MonoBehaviour
{
    public event EventHandler<int> OnRoundChanged;
    [SerializeField] private Unit unitLeft;
    [SerializeField] private Unit unitRight;

    [SerializeField] private BattleUI battle_ui;
    private Unit currentUnit;
    private int roundNumber;

    public void Initialize(Unit unitLeft, Unit unitRight, BuffManager buffManager, Action RestartGame)
    {
        battle_ui.Initialize(unitLeft, unitRight, buffManager, RestartGame, this);
        
        unitLeft.IsTurn = true;
        unitLeft.IsApplyBuffOnThisTurn = false;
        unitRight.IsTurn = false;
        
        currentUnit = unitLeft;
        roundNumber = 0;
        StartNewRound();
        StartNewTurn();
    }
    
    private void Awake()
    {
        unitLeft.OnAttackEnded += OnAttackEnded_EndTurn;
        unitRight.OnAttackEnded += OnAttackEnded_EndTurn;
    }

    private void OnAttackEnded_EndTurn()
    {
        Debug.Log("End turn");
        //currentUnit.CheckBuffsDuration
        if (currentUnit != unitRight) {} else EndRound();
        
        //Change unit
        currentUnit = currentUnit == unitLeft ? unitRight : unitLeft;

        StartNewTurn();
        Debug.Log("New turn");
        //currentUnit.BuffsOnNewRoundCheck
        void EndRound()
        {
            Debug.Log("End round " + roundNumber);
            StartNewRound();
        }
    }

    void StartNewTurn()
    {
        currentUnit.IsTurn = true;
        currentUnit.IsApplyBuffOnThisTurn = false;
    }
    
    void StartNewRound()
    {
        roundNumber++;
        OnRoundChanged?.Invoke(this, roundNumber);
    }
}
