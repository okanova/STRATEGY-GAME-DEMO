using Managers;
using UnityEngine;

namespace Soldiers
{
    public class SoldierBase : MonoBehaviour
    {
        public SoldierType soldierType;
        [SerializeField] private GameObject _model;
    }
}
