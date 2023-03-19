using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Managers;
using UnityEngine;

public class House : BuildingBase, IPopulationChanger
{
   protected override void SetBuilding()
   {
      base.SetBuilding();
      
      ChangePopulation(UIManager.Instance.SourceController.SourceModel.currentPopulation, 
         UIManager.Instance.SourceController.SourceModel.maxPopulation +
         BuildingManager.Instance.buildingSettings.extraPopulation);
   }

   public bool CheckPopulation()
   {
      return true;
   }

   public void ChangePopulation(int current, int max)
   {
      UIManager.Instance.PopulationInvoke(current, max);
   }
}
