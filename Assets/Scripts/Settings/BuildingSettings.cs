using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu (fileName = nameof(BuildingSettings), menuName = "ScriptableObject/" + nameof(BuildingSettings))]
    public class BuildingSettings : ScriptableObject
    {
        [Header("GENERAL")]
        public List<BuildingTypeValues> buildingTypeValuesList;
        
        [Header("HOUSE")]
        public int extraPopulation;

        [Header("POWER PLANT")] 
        public float goldEarnTimer;
        public int goldEarnValue;
    }
    
    [Serializable]
    public class BuildingTypeValues
    {
        public BuildingType buildingType;
        public int cost;
        public int health;
    }
}
