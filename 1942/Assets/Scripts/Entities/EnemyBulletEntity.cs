namespace com.emad.game.entities
{
    using UnityEngine;

    public class EnemyBulletEntity : Entity
    {
        void Update()
        {
            Tick();
        }

        protected override void UnSpawn()
        {
            ObjectPool<EnemyBulletEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawn(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            transform.position = parentTransform.position;
            _entitySpeed = GameSettings.Instance.EnemyBulletSpeed;
            StartCoroutine(UnspawnProcess());
        }
    }
}

