using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Unit unitLeft;
    [SerializeField] private Unit unitRight;
    [SerializeField] private Button unitLeftAttackButton;
    [SerializeField] private Button unitRightAttackButton;
    [SerializeField] private Button unitLeftApplyRandomBuff;
    [SerializeField] private Button unitRightApplyRandomBuff;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text roundNumberText;

    private BuffManager buff_manager;
    private Unit currentUnit;
    private int roundNumber;

    private void Awake()
    {
        buff_manager = GetComponent<BuffManager>();
        Unit.OnAnyDead += Restart;
        unitLeft.OnAttackEnded += OnAttackEnded_EndTurn;
        unitRight.OnAttackEnded += OnAttackEnded_EndTurn;
        
        restartButton.onClick.AddListener(Restart);
        unitLeftAttackButton.onClick.AddListener( () => unitLeft.Attack(unitRight));
        unitRightAttackButton.onClick.AddListener(() => unitRight.Attack(unitLeft));
        unitLeftApplyRandomBuff.onClick.AddListener(()=> unitLeft.ApplyRandomBuff(buff_manager));
        unitRightApplyRandomBuff.onClick.AddListener(()=> unitRight.ApplyRandomBuff(buff_manager));
    }

    private void Start()
    {
        SetupGame();
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
        roundNumberText.text = "Round:" + roundNumber;
        Debug.Log("Start round " + roundNumber);
    }
    
    private void SetupGame()
    {
        unitLeft.Initialize();
        unitRight.Initialize();

        unitLeft.IsTurn = true;
        unitLeft.IsApplyBuffOnThisTurn = false;
        unitRight.IsTurn = false;

        currentUnit = unitLeft;
        roundNumber = 0;
        StartNewRound();
        StartNewTurn();
    }
    
    private void Restart()
    {
        Debug.Log("Restart game");
        SetupGame();
    }
}