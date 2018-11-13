namespace com.emad.game
{
    using UnityEngine;

    public class MeteorEntity : Entity
    {
        protected override void UnSpawn()
        {
            ObjectPool<MeteorEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawn(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.MeteorZLayer;
            base.OnSpawn(parentTransform);
            transform.Rotate(0, 0, Random.Range(0, 360));
            _entitySpeed = GameSettings.Instance.MeteorSpeed;
        }
    }

}