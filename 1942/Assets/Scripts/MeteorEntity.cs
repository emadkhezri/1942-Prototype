namespace com.emad.game
{

    public class MeteorEntity : Entity
    {
        public override void Init()
        {
            base.Init();
            _entitySpeed = GameSettings.Instance.MeteorSpeed;
        }
    }

}