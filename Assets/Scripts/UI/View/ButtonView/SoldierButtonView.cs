using System.Linq;
using Interfaces;
using Managers;
using UnityEngine;

namespace UI.View.ButtonView
{
    public class SoldierButtonView : BaseButtonView, IPopulationChanger, IGoldChanger
    {
        public SoldierType soldierType;
        private int _cost;
        public bool isResearcher;

        protected override void OnButtonClick()
        {
           foreach (var soldier in SoldierManager.Instance.soldierSettings.soldierTypeValuesList
                        .Where(soldier => soldier.soldierType == soldierType))
               _cost = isResearcher ? soldier.researchCost : soldier.cost;
           
           if (!CheckPopulation()) return;
           if (!CheckGold()) return;
           
           if (!isResearcher)
                ChangePopulation(UIManager.Instance.SourceController.SourceModel.currentPopulation + 1, 
                UIManager.Instance.SourceController.SourceModel.maxPopulation);
           
           ChangeGold(UIManager.Instance.SourceController.SourceModel.currentMoney - _cost);

           if (isResearcher)
           {
               UIManager.Instance.Research(soldierType);

               switch (soldierType)
               {
                   case SoldierType.Level1:
                       PoolManager.Instance.SoldierLevel1ButtonPool.Release(this);
                       break;
                   case SoldierType.Level2:
                       PoolManager.Instance.SoldierLevel2ButtonPool.Release(this);
                       break;
                   case SoldierType.Level3:
                       PoolManager.Instance.SoldierLevel3ButtonPool.Release(this);
                       break;
               }
               
              
           }
              
           else 
               BuildingManager.Instance.CreateSoldier(soldierType);
        }
        
        public bool CheckPopulation()
        {
            if (UIManager.Instance.SourceController.SourceModel.currentPopulation ==
                UIManager.Instance.SourceController.SourceModel.maxPopulation)
                return false;

            return true;
        }

        public void ChangePopulation(int current, int max)
        {
            UIManager.Instance.PopulationInvoke(current, max);
        }

        public bool CheckGold()
        {
            if (_cost > UIManager.Instance.SourceController.SourceModel.currentMoney)
                return false;

            return true;
        }

        public void ChangeGold(int gold)
        {
            UIManager.Instance.GoldInvoke(gold);
        }
    }
}
