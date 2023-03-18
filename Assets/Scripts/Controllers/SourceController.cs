using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceController : BaseController
{
    public GoldView GoldView { get; private set; }
    public PopulationView PopulationView { get; private set; }

    public SourceModel SourceModel { get; private set; }

    public SourceController(GoldView goldView, PopulationView populationView, SourceModel sourceModel)
    {
        GoldView = goldView;
        PopulationView = populationView;
        SourceModel = sourceModel;

        SourceModel.currentMoney = PlayerPrefs.GetInt(PlayerPrefsNames.MONEY);
        SourceModel.currentPopulation = PlayerPrefs.GetInt(PlayerPrefsNames.CURRENT_POPULATION);
        SourceModel.maxPopulation = Mathf.Max(PlayerPrefs.GetInt(PlayerPrefsNames.MAX_POPULATION), 10);
        
        UIManager.GoldChanger += SetGold;
        UIManager.PopulationChanger += SetPopulation;
    }

    private void SetGold(int gold)
    {
        SourceModel.currentMoney = gold;
        PlayerPrefs.SetInt(PlayerPrefsNames.MONEY, SourceModel.currentMoney);
        GoldView.SetSourceText(SourceModel.currentMoney);
    }

    private void SetPopulation(int current, int max)
    {
        SourceModel.currentPopulation = current;
        SourceModel.maxPopulation = max;
        PlayerPrefs.SetInt(PlayerPrefsNames.CURRENT_POPULATION, SourceModel.currentPopulation);
        PlayerPrefs.SetInt(PlayerPrefsNames.MAX_POPULATION, SourceModel.maxPopulation);
        PopulationView.SetSourceText(SourceModel.currentPopulation, SourceModel.maxPopulation);
    }
}
