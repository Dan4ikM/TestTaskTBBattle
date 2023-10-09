using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Unit unitLeft;
    [SerializeField] private Unit unitRight;
    [SerializeField] private Battle battle;
    [SerializeField] private BuffManager buffManager;//buffLibrary

    private void Awake()
    {
        Unit.OnAnyDead += RestartGame;
    }

    private void Start()
    {
        SetupGame();
    }
    
    private void SetupGame()
    {
        unitLeft.Initialize();
        unitRight.Initialize();
        battle.Initialize(unitLeft, unitRight, buffManager, RestartGame);
    }
    
    private void RestartGame()
    {
        Debug.Log("Restart game");
        SetupGame();
    }
}