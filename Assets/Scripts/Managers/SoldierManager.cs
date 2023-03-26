using System.Collections.Generic;
using Extensions;
using Interfaces;
using Settings;
using Soldiers;
using UnityEngine;

namespace Managers
{
    public class SoldierManager : MonoSingleton<SoldierManager>
    {
        public SoldierSettings soldierSettings;
        public List<SoldierBase> soldiers;
        
        
        public void CreateSoldier(SoldierType type)
        {
            SoldierBase Soldier() => (type) switch
            {
                (SoldierType.Level1) => PoolManager.Instance.Level1SoldierPool.Get(),
                (SoldierType.Level2) => PoolManager.Instance.Level2SoldierPool.Get(),
                (SoldierType.Level3) => PoolManager.Instance.Level3SoldierPool.Get(),
                (_) => null
            };
            
            
            foreach (var nest in BuildingManager.Instance.spawnerBarrack.nestPositionList)
            {
                if (nest.spawnPoint)
                {
                    SoldierBase soldier = Soldier();
                    soldier.transform.position = GridManager.Instance.coordinateX[Mathf.RoundToInt
                            (nest.nestPosition.x + BuildingManager.Instance.spawnerBarrack.transform.localPosition.x)].coordinateY[
                            Mathf.RoundToInt(nest.nestPosition.y + BuildingManager.Instance.spawnerBarrack.transform.localPosition.y)]
                        .transform.position;
                    
                    soldiers.Add(soldier);
                }
            }
        }
    }
}
