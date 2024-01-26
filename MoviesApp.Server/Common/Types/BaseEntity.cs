namespace MoviesApp.Server.Common.Types
{
    public abstract class BaseEntity<T> : IEquatable<BaseEntity<T>>
    {
        public T Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        #region Constructors and properties
        protected BaseEntity(T id)
        {
            if (!IsValidId(id))
                throw new ArgumentException();

            Id = id;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }
        #endregion

        #region IEquatable implementation
        public bool Equals(BaseEntity<T> other)
        {
            return Id.GetHashCode() == other.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity<T>);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion

        #region Private methods
        private bool IsValidId(T id)
        {
            return id is int || id is Guid || id is string || id is long;
        }
        #endregion
    }
}
