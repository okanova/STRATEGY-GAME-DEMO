using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
   public List<BaseButtonView> buttonList;
   public Information[] informationPanel;
   public Image image;
   

  public void OpenPanel(BuildingType type)
  {
      foreach (var infP in informationPanel)
      {
          if (infP.type == type)
          {
              image.sprite = infP.imageSprite;
          }
      }
  }
}

[Serializable]
public class Information
{
    public BuildingType type;
    public Sprite imageSprite;
    public List<Button> productions;
}
