namespace com.emad.game
{
    using System.Collections;
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

        /// <summary>
        /// Number of remaining items in the pool
        /// </summary>
        public int PoolSize => _poolStack?.Count ?? 0;

        private ObjectPool()
        {
            _poolContainer = new GameObject(typeof(T).Name);
        }

        /// <summary>
        /// Load the pool with the give size
        /// </summary>
        /// <param name="poolSize">Number of initial objects in the pool</param>
        /// <returns></returns>
        public void  Load(int poolSize=DEFAULT_POOL_SIZE)
        {
            _poolStack = new Stack<T>(DEFAULT_POOL_SIZE);
            Transform rootTransform = _poolContainer.transform;
            for (int i = 0; i < DEFAULT_POOL_SIZE; i++)
            {
                GameObject gameObject = new GameObject();
                _poolStack.Push(gameObject.AddComponent<T>());
                gameObject.SetActive(false);
                gameObject.transform.SetParent(rootTransform);
            }
        }

        /// <summary>
        /// Load the pool with the given objects
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public void Load(T[] objects)
        {
            _poolStack = new Stack<T>(objects.Length);
            Transform rootTransform = _poolContainer.transform;
            for (int i = 0; i < objects.Length; i++)
            {
                _poolStack.Push(objects[i]);
                objects[i].gameObject.SetActive(false);
                objects[i].gameObject.transform.SetParent(rootTransform);
            }
        }

        /// <summary>
        /// Get an object of type T from the pool
        /// </summary>
        /// <exception cref="InvalidOperationException">The pool is empty</exception>
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