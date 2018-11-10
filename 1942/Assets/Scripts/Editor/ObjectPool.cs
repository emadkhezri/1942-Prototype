namespace com.emad.game
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Signleton Generic object pool of Unity components
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : Component
    {
        private const int DEFAULT_POOL_SIZE = 10;
        /// <summary>
        /// Number of objects in the pool
        /// <Remark>It needs to be set before instantiation the pool</Remark>
        /// </summary>
        public static int PoolSize = DEFAULT_POOL_SIZE;

        private GameObject _poolContainer;

        private Stack<T> _poolStack;

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

        private ObjectPool()
        {
            _poolStack = new Stack<T>(PoolSize);
            _poolContainer = new GameObject(typeof(T).Name);
            Transform rootTransform = _poolContainer.transform;

            for (int i = 0; i < PoolSize; i++)
            {
                GameObject gameObject = new GameObject();
                _poolStack.Push(gameObject.AddComponent<T>());
                gameObject.SetActive(false);
                gameObject.transform.SetParent(rootTransform);
            }
        }

        /// <summary>
        /// Get an object of type T from the pool
        /// </summary>
        /// <returns>an active object of type T</returns>
        public T AcquireObject()
        {
            T item =_poolStack.Pop();
            item.gameObject.SetActive(true);
            return item;
        }

        /// <summary>
        /// Release an object of type T to the pool
        /// </summary>
        /// <param name="objectToRelease"></param>
        public void ReleaseObject(T objectToRelease)
        {
            objectToRelease.gameObject.SetActive(false);
            objectToRelease.transform.SetParent(_poolContainer.transform);
            _poolStack.Push(objectToRelease);
        }

        /// <summary>
        /// Clear the pool
        /// </summary>
        public void Clear()
        {
            Object.DestroyImmediate(_poolContainer);
            _poolStack.Clear();
            _instance = null;
        }
    }

}