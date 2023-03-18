using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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
   
   [SerializeField] private SourceModel _sourceModel;
   public SourceController SourceController { get; private set; }

   public void UIEnabled()
   {
       _standardSprite = buildingImage.sprite;
       SourceController = new SourceController(_goldView, _populationView, _sourceModel);
       PopulationChanger?.Invoke(_sourceModel.currentPopulation, _sourceModel.maxPopulation);
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
                          soldierButtonView =  PoolManager.Instance.SoldierLevel1ButtonPool.Get();
                          break;
                      case SoldierType.Level2:
                          soldierButtonView =  PoolManager.Instance.SoldierLevel2ButtonPool.Get();
                          break;
                      case SoldierType.Level3:
                          soldierButtonView =  PoolManager.Instance.SoldierLevel3ButtonPool.Get();
                          break;
                      default:
                          break;
                  }
                  
                  if (!soldierButtonView) return;
                  
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
}

[Serializable]
public class Information
{
    public BuildingType type;
    public Sprite imageSprite;
    public List<SoldierType> productions;
    public string text;
}
