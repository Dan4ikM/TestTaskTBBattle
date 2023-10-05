using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    [SerializeField] private int maxDuration;

    [SerializeField] private string name;

    public override string ToString()
    {
        return name;
    }
}

public struct ActiveBuff
{
    public Dictionary<Buff, int> buff_list;
    public Buff buff;
    public int duration;
}