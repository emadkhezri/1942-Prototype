namespace com.emad.game
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class MeteorSpawner : MonoBehaviour
    {
        [SerializeField]
        private MeteorEntity[] _meteors;
        

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
            while (true)
            {

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

                //Spawn a meteor entity
                MeteorEntity entity = ObjectPool<MeteorEntity>.Instance.AcquireObject();
                entity.Init();
                _activeMeteors.Add(entity);

                yield return new WaitForSeconds(GameSettings.Instance.MeteorSpawningInterval);
            }
        }

    }

}