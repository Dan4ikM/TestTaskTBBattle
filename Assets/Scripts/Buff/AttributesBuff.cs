using System;
using System.Collections.Generic;
using UnityEngine;

public class AttributesBuff : Buff
{
    public enum UseEventType
    {
        OnNewRound, OnAttack
    }
    
    public enum AttributeType
    {
        Armor, Vampirism
    }
    
    [Serializable]
    public struct BuffAttribute
    {
        public AttributeType attributeType;
        public int value;
    }

    [SerializeField] private List<BuffAttribute> attributes;
    public UseEventType type_use;

    public void ApplyBuff(Unit target)
    {
        foreach (var attribute in attributes)
        {
            switch (attribute.attributeType)
            {
                case AttributeType.Armor:
                    target.Armor += attribute.value;
                    break;
                case AttributeType.Vampirism:
                    target.Vampirism += attribute.value;
                    break;
            }
        }
    }
}
