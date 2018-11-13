namespace com.emad.game.spawners
{
    using UnityEngine;
    using System.Collections;

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
                entity.OnSpawn(transform);

                yield return new WaitForSeconds(SpawningInterval);
            }
        }
    }

}