// Decompiled with JetBrains decompiler
// Type: UnityExtensions.MonoSingleton`1
// Assembly: UnityExtensions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C1B5CC5E-2B65-466C-8CF4-38A55260988A
// Assembly location: C:\Unity\Pc\BirPcOyunu\Assets\Plugins\ArcadeClan\Extensions\Runtime\UnityExtensions.dll

using UnityEngine;

namespace Extensions
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static volatile T instance;

        public static T Instance
        {
            get
            {
                if ((bool) (Object) MonoSingleton<T>.instance)
                    return MonoSingleton<T>.instance;
                MonoSingleton<T>.instance = Object.FindObjectOfType<T>();
                if (!(bool) (Object) MonoSingleton<T>.instance)
                    MonoSingleton<T>.instance = new GameObject(nameof (T)).AddComponent<T>();
                return MonoSingleton<T>.instance;
            }
        }
    }
}