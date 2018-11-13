namespace com.emad.game
{

    public interface IEntity
    {
        /// <summary>
        /// Equivalent to Unity Update but it will be calling from EntityManager
        /// <code>Performance consideration</code>
        /// </summary>
        void Tick();
    }

}