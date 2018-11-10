namespace com.emad.game
{
    using UnityEngine;
    using UnityEditor;

    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {

        private GameSettings() { }

        private static GameSettings _instance;
        public static GameSettings Instance
        {
            get
            {
#if UNITY_EDITOR
                if (_instance == null)
                {
                    _instance = AssetDatabase.LoadAssetAtPath<GameSettings>("Assets/" + typeof(GameSettings).Name + ".asset");
                }
#endif

                return _instance;
            }
        }

        public void Load() => _instance = this;

        #region Meteor Settings

        [Header("Meteor Settings")]
        [SerializeField]
        private float _meteorSpeed = 2;
        public float MeteorSpeed => _meteorSpeed;

        private const float MIN_SPAWN_INTERVAL = 0.5f;
        private const float MAX_SPAWN_INTERVAL = 5f;
        [SerializeField]
        [Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL)]
        private float _meteorSpawningInterval = 2;
        public float MeteorSpawningInterval => _meteorSpawningInterval;

        [SerializeField]
        private Bounds _meteorSpawningBound;
        public Bounds MeteorSpawningBound => _meteorSpawningBound;
            
        #endregion
    }

}