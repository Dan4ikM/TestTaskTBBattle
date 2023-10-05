using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private List<Buff> buffs;

    public Buff GetRandomBuff(List<Buff> current_buffs)
    {
        List<Buff> new_buffs = buffs.ToList();
        foreach (var current_buff in current_buffs)
        {
            foreach (var new_buff in new_buffs)
            {
                if (current_buff == new_buff)
                {
                    new_buffs.Remove(new_buff);
                    break;
                }
            }
        }
        
        return new_buffs[Random.Range(0, new_buffs.Count)];
    }
}
