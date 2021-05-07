using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityExtensoes 
{
    public static class ExtensoesGameObject
    {
        public static T GetInterface<T>(this GameObject gameObject)
        {
            MonoBehaviour[] mono = gameObject.GetComponents<MonoBehaviour>();
            for (int i = 0; i < mono.Length; i++)
            {
                if (mono[i] is T interfaceT)
                {
                    return interfaceT;
                }
            }

            return default(T);
        }
    }

}



