namespace com.emad.game.spawners
{
    using UnityEngine;
    using System.Collections;
    using com.emad.game.entities;

    public abstract class EntitySpawner<T> : MonoBehaviour where T: Entity
    {
        [SerializeField]
        protected T[] _entityPrefabs;

        protected virtual float SpawningInterval { get; }

        void Awake()
        {
            for (int i = 0; i < _entityPrefabs.Length; i++)
            {
                ObjectPool<T>.Instance.Load(_entityPrefabs[i], _entityPrefabs[i].InstancesCount);
            }
            StartSpawningProcess();
        }

        protected virtual void StartSpawningProcess()
        {
            StartCoroutine(SpawnerProcess());
        }

        protected IEnumerator SpawnerProcess()
        {
            while (true)
            {
                //Spawn an entity
                T entity = ObjectPool<T>.Instance.AcquireObject();
                EntityManager.Instance.Add(entity);
                entity.OnSpawned(transform);

                yield return new WaitForSeconds(SpawningInterval);
            }
        }
    }

}