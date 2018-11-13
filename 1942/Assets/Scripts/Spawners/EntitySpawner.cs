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

        void Start()
        {
            for (int i = 0; i < _entityPrefabs.Length; i++)
            {
                ObjectPool<T>.Instance.Load(_entityPrefabs[i], _entityPrefabs[i].InstancesCount);
            }
            StartCoroutine(SpawnerProcess());
        }

        private IEnumerator SpawnerProcess()
        {
            while (true)
            {
                //Spawn an entity
                T entity = ObjectPool<T>.Instance.AcquireObject();
                EntityManager.Instance.Add(entity);
                entity.OnSpawn(transform);

                yield return new WaitForSeconds(SpawningInterval);
            }
        }
    }

}