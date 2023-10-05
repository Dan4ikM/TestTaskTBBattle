using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public event Action OnAttackEnded; 
    public static event Action OnAnyDead;
    
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 15;
    [SerializeField] private HealthSystem health_system;
    
    public bool IsTurn;
    public bool IsApplyBuffOnThisTurn;
    
    private int armor;
    public int Armor
    {
        get => armor;
        set
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;
            armor = value;
        }
    }

    private int vampirism;
    public int Vampirism
    {
        get => vampirism;
        set
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;
            vampirism = value;
        }
    }

    private List<Buff> active_buffs;

    public void Initialize()
    {
        health = 100;
        Vampirism = 0;
        Armor = 0;
        active_buffs = new List<Buff>();
    }

    public void ApplyDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health <= 0)
        {
            Debug.Log(gameObject + " dead!");
            OnAnyDead?.Invoke();
        }
    }
    
    public void Attack(Unit target)
    {
        if (IsTurn) {} else return;

        IsTurn = false;
        
        target.ApplyDamage(damage);
        OnAttackEnded?.Invoke();
    }

    public void ApplyRandomBuff(BuffManager buff_manager)
    {
        if (IsTurn) {} else return;
        
        if (active_buffs.Count < 2) {} else return;
        
        if (!IsApplyBuffOnThisTurn) {} else return;

        IsApplyBuffOnThisTurn = true;

        Buff new_buff = buff_manager.GetRandomBuff(active_buffs);
        Debug.Log(new_buff.ToString());
        active_buffs.Add(new_buff);
        
        if (new_buff is AttributesBuff new_attributes_buff) 
            new_attributes_buff.ApplyBuff(this);
    }
}
