namespace com.emad.game
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public abstract class EntitySpawner<T> : MonoBehaviour where T: Entity
    {
        [SerializeField]
        protected T[] _entityPrefabs;        

        private List<Entity> _activeEntities;

        protected float _spawningIntervals;

        // Use this for initialization
        void Start()
        {
            Initialize();
            _activeEntities = new List<Entity>();
            for (int i = 0; i < _entityPrefabs.Length; i++)
            {
                ObjectPool<T>.Instance.Load(_entityPrefabs[i], _entityPrefabs[i].InstancesCount);
            }
            StartCoroutine(SpawnInterval());
        }

        void Update()
        {
            for (int i = 0; i < _activeEntities.Count; i++)
            {
                _activeEntities[i].Tick();
            }
        }

        /// Using template method pattern
        protected virtual void Initialize() {}

        private IEnumerator SpawnInterval()
        {
            while (true)
            {

                //Unspawn invalid entities
                for (int i = 0; i < _activeEntities.Count; i++)
                {
                    if (!_activeEntities[i].IsValid())
                    {
                        ObjectPool<T>.Instance.ReleaseObject((T)_activeEntities[i]);
                        _activeEntities.RemoveAt(i);
                        yield return null;
                    }

                }

                //Spawn an entity
                Entity entity = ObjectPool<T>.Instance.AcquireObject();
                entity.Init();
                _activeEntities.Add(entity);

                yield return new WaitForSeconds(_spawningIntervals);
            }
        }

    }

}