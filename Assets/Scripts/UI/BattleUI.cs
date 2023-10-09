using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private UnitUI leftUnitUI;
    [SerializeField] private UnitUI rightUnitUI;
    
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text roundNumberText;

    public void Initialize(Unit left_unit, Unit right_unit, BuffManager buff_manager, Action OnRestarted, Battle battle)
    {
        leftUnitUI.Initialize(left_unit, right_unit, buff_manager);
        rightUnitUI.Initialize(right_unit, left_unit, buff_manager);
        restartButton.onClick.AddListener(OnRestarted.Invoke);
        battle.OnRoundChanged += Turn_OnRoundChanged;
    }

    private void Turn_OnRoundChanged(object sender, int e)
    {
        UpdateRoundText(e);
    }
    
    private void UpdateRoundText(int round_number)
    {
        roundNumberText.text = "Round: " + round_number;
    }
}
