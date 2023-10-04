using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField] private Button leftAttackButton;  
    [SerializeField] private Button rightAttackButton;  
    
    public void Initialize(Unit unitLeft, Unit unitRight)
    {
        leftAttackButton.onClick.AddListener(() => AttackSystem.Attack(unitLeft,unitRight));
        rightAttackButton.onClick.AddListener(() => AttackSystem.Attack(unitRight,unitLeft));
    }
    
    /*
     *UI
     *GameUI
     * UnitUI Left
     * UnitUI Right
     * Round Text
     * Restart Button
     * 
     * UnitUI
     *  ActionsUI
     *  StatsUI
     *  BuffUI
     *
     * ActionsUI
     *  ActionButton
     *
     * Game
     */
}
