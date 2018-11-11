namespace com.emad.game
{
    using UnityEngine;
    public class EnemyEntity : Entity
    {
        
        public override void Init()
        {
            base.Init();
            _entitySpeed = GameSettings.Instance.EnemySpeed;
        }
    }

}