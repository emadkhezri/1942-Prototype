namespace com.emad.game
{
    using UnityEngine;
    public class EnemyEntity : Entity
    {
        
        public override void Init(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            base.Init(parentTransform);
            _entitySpeed = GameSettings.Instance.EnemySpeed;
        }
    }

}