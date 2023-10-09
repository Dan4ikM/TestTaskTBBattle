using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private Button unitAttackButton;
    [SerializeField] private Button unitApplyRandomBuffButton;
    [SerializeField] private BuffSystemUI buffSystemUI;

    public void Initialize(Unit unit, Unit target, BuffManager buff_manager)
    {
        unitAttackButton.onClick.AddListener( () => unit.Attack(target));
        unitApplyRandomBuffButton.onClick.AddListener(()=> unit.ApplyRandomBuff(buff_manager));
    }
}
