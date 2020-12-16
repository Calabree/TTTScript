using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class CharacterStats
{

    public float BaseValue;

    public float value {
        get
        {
            if (isDirty || BaseValue !=lasBaseValue)
            {
                lasBaseValue = BaseValue;
                _value = CalculatedFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }
    protected bool isDirty = true; 
    protected float _value;
    protected float lasBaseValue = float.MinValue;

    protected readonly List<StatMod> statModifiers;
    public ReadOnlyCollection<StatMod> StatModifiers;

    public CharacterStats()
    {
        statModifiers = new List<StatMod>();
        StatModifiers = statModifiers.AsReadOnly();
    }
    public CharacterStats(float baseValue):this()
    {
        BaseValue = baseValue;
        //creates read only list of statModifier list (no changes permited)
    }

    public virtual void AddModifier(StatMod mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort();
    }

    protected virtual int CompareModifierOrder(StatMod a, StatMod b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }

    public virtual bool RemoveModifier(StatMod mod)
    {
        
        if(statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }
    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;
        for (int i=statModifiers.Count-1 ; i>=0; i--)// remove items traversing backwards 
        {
            if(statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    protected virtual float CalculatedFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0f;

        for (int i =0; i<statModifiers.Count; i++)
        {
            StatMod mod = statModifiers[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if(mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;
                if (i+1>=statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }

}
