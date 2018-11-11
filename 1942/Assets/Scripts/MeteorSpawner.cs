namespace com.emad.game
{

    public class MeteorSpawner : EntitySpawner
    {
        protected override void Initialize()
        {
            base.Initialize();
            _spawningIntervals = GameSettings.Instance.MeteorSpawningInterval;
        }
    }

}