namespace com.emad.game
{

    public class MeteorSpawner : EntitySpawner<MeteorEntity>
    {
        protected override void Initialize()
        {
            base.Initialize();
            _spawningIntervals = GameSettings.Instance.MeteorSpawningInterval;
        }
    }

}