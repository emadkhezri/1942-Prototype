namespace com.emad.game
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class MeteorSpawner : MonoBehaviour
    {
        [SerializeField]
        private MeteorEntity[] _meteors;

        [SerializeField]
        private bool _keepSpawning = true;
        [SerializeField]
        private float _spawningTimeInterval = 2;

        private List<MeteorEntity> _activeMeteors;

        // Use this for initialization
        void Start()
        {
            _activeMeteors = new List<MeteorEntity>();
            for (int i = 0; i < _meteors.Length; i++)
            {
                ObjectPool<MeteorEntity>.Instance.Load(_meteors[i], _meteors[i].InstancesCount);
            }
            StartCoroutine(SpawnInterval());
        }

        void Update()
        {
            for (int i = 0; i < _activeMeteors.Count; i++)
            {
                _activeMeteors[i].Tick();
            }
        }

        private IEnumerator SpawnInterval()
        {
            while (_keepSpawning)
            {
                yield return new WaitForSeconds(_spawningTimeInterval);

                //Unspawn invalid meteors
                for (int i = 0; i < _activeMeteors.Count; i++)
                {
                    if (!_activeMeteors[i].IsValid())
                    {
                        ObjectPool<MeteorEntity>.Instance.ReleaseObject(_activeMeteors[i]);
                        _activeMeteors.Remove(_activeMeteors[i]);
                        yield return null;
                    }

                }

                MeteorEntity entity = ObjectPool<MeteorEntity>.Instance.AcquireObject();
                entity.Init();
                _activeMeteors.Add(entity);
            }
        }

    }

}