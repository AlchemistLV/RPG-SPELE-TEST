using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus {
    public int BonusValue { get; set; }
    public StatBonus(int bonusValue)
    {
        this.BonusValue = BonusValue;
        Debug.Log("LEVEL UP, STATS UPDATED!");
    }
}
