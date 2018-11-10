namespace com.emad.game
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Signleton Generic object pool of Unity Component types
    /// </summary>
    /// <typeparam name="T">Unity Component Types</typeparam>
    public class ObjectPool<T> where T : Component
    {
        public const int DEFAULT_POOL_SIZE = 10;

        private GameObject _poolContainer;

        private List<T> _poolList;

        private static ObjectPool<T> _instance; 
        public static ObjectPool<T> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ObjectPool<T>();

                return _instance;
            }
        }

        /// <summary>
        /// Number of remaining items in the pool
        /// </summary>
        public int PoolSize => _poolList?.Count ?? 0;

        private ObjectPool()
        {
            _poolContainer = new GameObject($"{typeof(T).Name}-Pool");
            _poolList = new List<T>(DEFAULT_POOL_SIZE);
        }

        /// <summary>
        /// Load the pool with the give size
        /// </summary>
        /// <param name="poolSize">Number of initial objects in the pool</param>
        /// <returns></returns>
        public void  Load(int poolSize=DEFAULT_POOL_SIZE)
        {
            for (int i = 0; i < DEFAULT_POOL_SIZE; i++)
            {
                T item = new GameObject().AddComponent<T>();
                ReleaseObject(item);
            }
        }

        /// <summary>
        /// Load the pool with the given objects
        /// </summary>
        /// <remarks>Objects aren't prefabs.</remarks>
        /// <param name="objects">Array objects of type T</param>
        /// <returns></returns>
        public void Load(T[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                T item = objects[i];
                ReleaseObject(item);
            }
        }

        /// <summary>
        /// Load the pool with count number of prefab
        /// </summary>
        /// <param name="prefab">Prefab to be instantiated in the pool</param>
        /// <param name="count">Number of instantiation</param>
        public void Load(T prefab, int count)
        {
            for (int i = 0; i < count; i++)
            {
                T item = Object.Instantiate(prefab);
                ReleaseObject(item);
            }
        }

        /// <summary>
        /// Get an object of type T from the pool
        /// </summary>
        /// <exception cref="InvalidOperationException">The pool is empty</exception>
        /// <returns>an active object of type T</returns>
        public T AcquireObject()
        {
            int acquireIndex = Random.Range(0, _poolList.Count);
            T item = _poolList[acquireIndex];
            _poolList.RemoveAt(acquireIndex);
            item.gameObject.SetActive(true);
            item.transform.SetParent(null);
            return item;
        }

        /// <summary>
        /// Release an object of type T to the pool
        /// </summary>
        /// <param name="objectToRelease"></param>
        public void ReleaseObject(T objectToRelease)
        {
            objectToRelease.transform.SetParent(_poolContainer.transform);
            objectToRelease.gameObject.SetActive(false);
            _poolList.Add(objectToRelease);
        }

        /// <summary>
        /// Clear the pool
        /// </summary>
        public void Clear()
        {
            Object.DestroyImmediate(_poolContainer);
            _poolList.Clear();
            _instance = null;
        }
    }

}