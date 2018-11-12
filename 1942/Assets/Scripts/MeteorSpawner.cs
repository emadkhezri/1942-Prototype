namespace com.emad.game
{

    public class MeteorSpawner : EntitySpawner<MeteorEntity>
    {

        protected override void Tick()
        {
            _spawningIntervals = GameSettings.Instance.MeteorSpawningInterval;
        }
    }

}