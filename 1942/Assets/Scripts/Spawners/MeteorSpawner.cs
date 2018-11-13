namespace com.emad.game.spawners
{

    public class MeteorSpawner : EntitySpawner<MeteorEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.MeteorSpawningInterval;
    }

}