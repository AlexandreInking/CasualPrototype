using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Inking.CharacterStats
{
    [Serializable]
    public class CharacterStat
    {
        public float baseValue;

        public float Value {
            get {
                if (isDirty || baseValue != lastBaseValue)
                {
                    lastBaseValue = baseValue;
                    value = CalculateFinalValue();
                    isDirty = false;
                }
                return value;
            }
        }

        private bool isDirty = true;
        public float value;
        private float lastBaseValue = float.MinValue;

        private readonly List<StatModifier> statMods;
        public readonly ReadOnlyCollection<StatModifier> StatMods;

        public CharacterStat()
        {
            statMods = new List<StatModifier>();
            StatMods = statMods.AsReadOnly();
        }

        public CharacterStat(float baseValue) : this()
        {
            this.baseValue = baseValue;
        }
    
        public void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statMods.Add(mod);
            statMods.Sort(CompareModifierOrder);
        }

        private int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.order < b.order)
            {
                return -1;
            }
            else if (a.order > b.order)
            {
                return 1;
            }
            return 0;
        }

        public bool RemoveModifier(StatModifier mod)
        {
            if (statMods.Remove(mod))
            {
                isDirty = true;
                return true;
            }

            return false;
        }

        public bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;


            for (int i = statMods.Count - 1; i >= 0; i--)
            {
                if (statMods[i].source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statMods.RemoveAt(i);
                }
            }

            return didRemove;
        }

        public float CalculateFinalValue()
        {
            float finalValue = baseValue;
            float sumPercentAdd = 0;

            for(int i = 0; i < statMods.Count; i++)
            {
                StatModifier mod = statMods[i];

                if (mod.type == StatModType.Flat)
                {
                    finalValue += mod.value;
                }
                else if (mod.type == StatModType.AddPercent)
                {
                    sumPercentAdd += mod.value;

                    if (i + 1 >= statMods.Count || statMods[i + 1].type != StatModType.AddPercent)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.type == StatModType.MultPercent)
                {
                    finalValue *= 1 + mod.value;
                }

            }

            return (float)Math.Round(finalValue, 4);
        }
    }
}
