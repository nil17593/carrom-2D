using System.Collections;
using UnityEngine;


namespace BSWCarrom
{
    /// <summary>
    ///Generic singletone class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance;

        public static T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}