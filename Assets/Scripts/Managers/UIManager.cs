using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
   public List<BaseButtonView> buttonList;
   public Information[] informationPanel;
   public Image image;
   public TextMeshProUGUI informationText;
   private Sprite _standardSprite;
  

   public void UIEnabled()
   {
       _standardSprite = image.sprite;
   }
   
   public void OpenPanel(BuildingType type)
   {
      foreach (var infP in informationPanel)
      {
          if (infP.type == type)
          {
              image.sprite = infP.imageSprite;
              informationText.text = infP.text;
          }
      }
  }

   public void ClosePanel()
   {
       image.sprite = _standardSprite;
       informationText.text = "";
   }
}

[Serializable]
public class Information
{
    public BuildingType type;
    public Sprite imageSprite;
    public List<Button> productions;
    public string text;
}
