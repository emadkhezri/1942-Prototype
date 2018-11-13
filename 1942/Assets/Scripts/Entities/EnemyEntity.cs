namespace com.emad.game.entities
{
    using UnityEngine;
    public class EnemyEntity : Entity
    {
        protected override void UnSpawn()
        {
            ObjectPool<EnemyEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawn(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            base.OnSpawn(parentTransform);
            _entitySpeed = GameSettings.Instance.EnemySpeed;
        }
    }

}