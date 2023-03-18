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

       foreach (var infP in informationPanel)
      {
          if (infP.type == type)
          {
              buildingImage.sprite = infP.imageSprite;
              informationText.text = infP.text;

              RectTransform rect;

              foreach (var production in infP.productions)
              {
                  SoldierButtonView SoldierButton() => (production) switch
                  {
                      (SoldierType.Level1) => PoolManager.Instance.SoldierLevel1ButtonPool.Get(),
                      (SoldierType.Level2) => PoolManager.Instance.SoldierLevel2ButtonPool.Get(),
                      (SoldierType.Level3) => PoolManager.Instance.SoldierLevel3ButtonPool.Get(),
                      (_) => null
                  };
                  
                  SoldierButton().transform.SetParent(_soldierParent);
                  rect = SoldierButton().GetComponent<RectTransform>();
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
