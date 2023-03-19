using UnityEngine;

namespace Environment
{
    public class Environment : MonoBehaviour
    {
        public Transform map;
        public Transform grid;
        public Transform build;
        public GameObject mouseTarget;
        public void CreateMap()
        {
            MouseTargetEnable(false);
        }

        public void MouseTargetEnable(bool isActive)
        {
       
        }
    }
}
