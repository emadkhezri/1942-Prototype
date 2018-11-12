namespace com.emad.game
{

    public class EnemyEntity : Entity
    {
        
        public override void Init()
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            base.Init();
            _entitySpeed = GameSettings.Instance.EnemySpeed;
        }
    }

}