namespace com.emad.game.spawners
{
    using com.emad.game.entities;

    public class MeteorSpawner : EntitySpawner<MeteorEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.MeteorSpawningInterval;
    }

}