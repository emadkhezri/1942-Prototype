namespace com.emad.game
{
    using UnityEngine;

    public class MeteorSpawner : MonoBehaviour
    {
        [SerializeField]
        private MeteorEntity[] _meteors;


        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < _meteors.Length; i++)
            {
                ObjectPool<MeteorEntity>.Instance.Load(_meteors[i], _meteors[i].InstancesCount);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}