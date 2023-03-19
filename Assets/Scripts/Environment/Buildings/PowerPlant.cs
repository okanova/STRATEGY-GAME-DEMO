using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Managers;
using UnityEngine;

public class PowerPlant : BuildingBase, IGoldChanger
{
    protected override void SetBuilding()
    {
        base.SetBuilding();

        StartCoroutine("EarnGoldRoutine");
    }

    IEnumerator EarnGoldRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(BuildingManager.Instance.buildingSettings.goldEarnTimer);
            ChangeGold(UIManager.Instance.SourceController.SourceModel.currentMoney + 
                       BuildingManager.Instance.buildingSettings.goldEarnValue);
        }
    }

    public bool CheckGold()
    {
        return true;
    }

    public void ChangeGold(int gold)
    {
        UIManager.Instance.GoldInvoke(gold);
    }
}
