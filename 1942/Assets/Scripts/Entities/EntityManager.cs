namespace com.emad.game
{
    using UnityEngine;
    using System.Collections.Generic;

    public class EntityManager : MonoBehaviour
    {
        private static EntityManager _instance;
        /// <summary>
        /// Singletone of TickHandler
        /// </summary>
        public static EntityManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<EntityManager>();
                    if (_instance == null)
                        _instance = new GameObject("EntityManager").AddComponent<EntityManager>();
                }
                return _instance;
            }
        }
        private List<IEntity> _entities = new List<IEntity>();

        public void Add(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(IEntity entity)
        {
            _entities.Remove(entity);
        }
        void Update()
        {
            for (int i = _entities.Count - 1; i >= 0; i--)
            {
                _entities[i].Tick();
            }
        }
    }

}