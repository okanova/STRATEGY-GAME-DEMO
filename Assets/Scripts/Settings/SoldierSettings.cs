using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu (fileName = nameof(SoldierSettings), menuName = "ScriptableObject/" + nameof(SoldierSettings))]
    public class SoldierSettings : ScriptableObject
    {
        public List<SoldierTypeValues> soldierTypeValuesList;
    }
    
    [Serializable]
    public class SoldierTypeValues
    {
        public SoldierType soldierType;
        public int cost;
        public int researchCost;
        public int health;
        public int attack;
    }
}
