namespace GameDrones.Domain
{
    /// <summary>
    /// Base class for all entities.
    /// </summary>
    public class Entity : IEntity
    {
        #region Fields

        /// <inheritdoc />
        public int Id { get; set; }

        #endregion
    }
}
