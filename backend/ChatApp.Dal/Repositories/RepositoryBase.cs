namespace ChatApp.Dal.Repositories
{
    public class RepositoryBase<TEntity>
        where TEntity : class
    {
        protected readonly ChatAppDbContext chatDbContext;

        public RepositoryBase(ChatAppDbContext chatDbContext)
        {
            this.chatDbContext = chatDbContext;
        }

        public TEntity Insert(TEntity entity)
        {
            chatDbContext.Set<TEntity>().Add(entity);
            return entity;
        }
    }
}
