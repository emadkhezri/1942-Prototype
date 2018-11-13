namespace com.emad.game
{

    public interface IEntity
    {
        /// <summary>
        /// The Entity shouldn't received any tick if it's disabled
        /// </summary>
        bool IsDisabled { get; }
        /// <summary>
        /// Equivalent to Unity Update but it will be calling from EntityManager
        /// <code>Performance consideration</code>
        /// </summary>
        void Tick();
    }

}