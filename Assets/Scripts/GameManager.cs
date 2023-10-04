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
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text roundNumberText;

    private Unit currentUnit;
    private int roundNumber;
        
    private void Awake()
    {
        Unit.OnAnyDead += Restart;
        unitLeft.OnAttackEnded += OnAttackEnded_EndTurn;
        unitRight.OnAttackEnded += OnAttackEnded_EndTurn;
        
        restartButton.onClick.AddListener(Restart);
        unitLeftAttackButton.onClick.AddListener( () => unitLeft.Attack(unitRight));
        unitRightAttackButton.onClick.AddListener(() => unitRight.Attack(unitLeft));
    }

    private void Start()
    {
        SetupGame();
    }

    private void OnAttackEnded_EndTurn()
    {
        Debug.Log("End turn");

        if (currentUnit != unitRight) {} else EndRound();
        
        currentUnit = currentUnit == unitLeft ? unitRight : unitLeft;
        currentUnit.IsTurn = true;
        Debug.Log("New turn");
        
        void EndRound()
        {
            Debug.Log("End round " + roundNumber);
            StartNewRound();
        }
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
        unitRight.IsTurn = false;

        currentUnit = unitLeft;
        roundNumber = 0;
        StartNewRound();
    }
    
    private void Restart()
    {
        Debug.Log("Restart game");
        SetupGame();
    }
}