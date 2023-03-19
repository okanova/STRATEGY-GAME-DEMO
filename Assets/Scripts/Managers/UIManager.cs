using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Extensions;
using Models;
using TMPro;
using UI.View;
using UI.View.ButtonView;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public delegate void SetGold(int money);
    public delegate void SetPopulation(int currentPopulation, int maxPopulation);
  
    public class UIManager : MonoSingleton<UIManager>
    {
        public static event SetGold GoldChanger;
        public static event SetPopulation PopulationChanger;
   
        public Information[] informationPanel;
        public Image buildingImage;
        public TextMeshProUGUI informationText;
        [SerializeField] private Transform _soldierParent;
        private Sprite _standardSprite;
   
        [SerializeField] private GoldView _goldView;
        [SerializeField] private PopulationView _populationView;

        public SourceController SourceController { get; private set; }

        public void UIEnabled()
        {
            _standardSprite = buildingImage.sprite;
           
            SourceController = new SourceController(_goldView, _populationView);
            GoldInvoke(SourceController.SourceModel.currentMoney);
            PopulationInvoke(SourceController.SourceModel.currentPopulation,
                SourceController.SourceModel.maxPopulation);
        }

        public void GoldInvoke(int money)
        {
            GoldChanger?.Invoke(money);
        }

        public void PopulationInvoke(int current, int max)
        {
            PopulationChanger?.Invoke(current, max);
        }
   
        public void OpenPanel(BuildingType type)
        {
            ClosePanel();

            RectTransform rect;
            SoldierButtonView soldierButtonView = null;

            foreach (var infP in informationPanel)
            {
                if (infP.type == type)
                {
                    buildingImage.sprite = infP.imageSprite;
                    informationText.text = infP.text;
                    
                    foreach (var production in infP.productions)
                    {
                        switch (production)
                        {
                            case SoldierType.Level1:
                                soldierButtonView = PoolManager.Instance.SoldierLevel1ButtonPool.Get();
                                break;
                            case SoldierType.Level2:
                                soldierButtonView = PoolManager.Instance.SoldierLevel2ButtonPool.Get();
                                break;
                            case SoldierType.Level3:
                                soldierButtonView = PoolManager.Instance.SoldierLevel3ButtonPool.Get();
                                break;
                            default:
                                break;
                        }
                  
                        if (!soldierButtonView) return;

                        soldierButtonView.isResearcher = type == BuildingType.SoldierUnit;
                        soldierButtonView.transform.SetParent(_soldierParent);
                        rect = soldierButtonView.GetComponent<RectTransform>();
                        rect.localScale = Vector3.one;
                        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0);
                    }
                }
            }
        }
        
        public void ClosePanel()
        {
            buildingImage.sprite = _standardSprite;
            informationText.text = "";

            SoldierButtonView[] soldierButtons = _soldierParent.GetComponentsInChildren<SoldierButtonView>();

            if (soldierButtons.Length == 0) return;
       
            foreach (SoldierButtonView soldierButton in soldierButtons)
            {
                switch (soldierButton.soldierType)
                {
                    case SoldierType.Level1:
                        PoolManager.Instance.SoldierLevel1ButtonPool.Release(soldierButton);
                        break;
                    case SoldierType.Level2:
                        PoolManager.Instance.SoldierLevel2ButtonPool.Release(soldierButton);
                        break;
                    case SoldierType.Level3:
                        PoolManager.Instance.SoldierLevel3ButtonPool.Release(soldierButton);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Research(SoldierType soldierType)
        {
            foreach (var infP in informationPanel)
            {
                if (infP.type == BuildingType.PowerPlant)
                {
                    infP.productions.Remove(soldierType);
                }
                else if (infP.type == BuildingType.Barrack)
                {
                    infP.productions.Add(soldierType);
                }
            }
        }
    }

    [Serializable]
    public class Information
    {
        public BuildingType type;
        public Sprite imageSprite;
        public List<SoldierType> productions;
        public string text;
    }
}