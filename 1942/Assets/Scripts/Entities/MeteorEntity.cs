namespace com.emad.game.entities
{
    using UnityEngine;

    public class MeteorEntity : Entity
    {
        public override void DeSpawn()
        {
            base.DeSpawn();
            ObjectPool<MeteorEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawned(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.MeteorZLayer;
            base.OnSpawned(parentTransform);
            transform.Rotate(0, 0, Random.Range(0, 360));
            _entitySpeed = GameSettings.Instance.MeteorSpeed;
        }
    }

}