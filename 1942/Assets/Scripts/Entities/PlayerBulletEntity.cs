namespace com.emad.game.entities
{
    using UnityEngine;
    public class PlayerBulletEntity : Entity
    {

        protected override void UnSpawn()
        {
            ObjectPool<PlayerBulletEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawn(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.PlayerZLayer;
            transform.position = parentTransform.position;
            _entitySpeed = GameSettings.Instance.PlayerBulletSpeed;
            StartCoroutine(UnspawnProcess());
        }
    }
}

