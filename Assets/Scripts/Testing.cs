using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inking.CharacterStats;

[SerializeField]
public class Testing : MonoBehaviour
{
    public CharacterStat body, mind, control, energy; // Main Stats

    public CharacterStat hitPoints;
    public CharacterStat HitPoints { get { return hitPoints; } set { hitPoints = value; } }

    public CharacterStat hitRegen;
    public CharacterStat HitRegen { get { return hitRegen; } set { hitRegen = value; } }

    public CharacterStat manaPoints;
    public CharacterStat ManaPoints { get { return manaPoints; } set { manaPoints = value; } }

    public CharacterStat manaRegen;
    public CharacterStat ManaRegen { get { return manaRegen; } set { manaRegen = value; } }

    public CharacterStat phiAttack;
    public CharacterStat PhiAttack { get { return phiAttack; } set { phiAttack = value; } }

    public CharacterStat magAttack;
    public CharacterStat MagAttack { get { return magAttack; } set { magAttack = value; } }

    public CharacterStat speedAttack;
    public CharacterStat SpeedAttack { get { return speedAttack; } set { speedAttack = value; } }

    public CharacterStat phiDefense;
    public CharacterStat PhiDefense { get { return phiDefense; } set { phiDefense = value; } }

    public CharacterStat magDefense;
    public CharacterStat MagDefense { get { return magDefense; } set { magDefense = value; } }

    public CharacterStat speedMove;
    public CharacterStat SpeedMove { get { return speedMove; } set { speedMove = value; } }

    public CharacterStat statusResist;
    public CharacterStat StatusResist { get { return statusResist; } set { statusResist = value; } }

    // Update is called once per frame
    void Update()
    {
        
    }
}
