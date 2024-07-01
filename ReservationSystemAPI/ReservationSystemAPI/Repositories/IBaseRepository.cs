


namespace ReservationSystemAPI.Repositories
{
    public interface IBaseRepository<E, D>
    {
        public Task<List<E>> GetAllAsync();

        public Task<E> AddAsync(D model);

        public Task<E> GetById(int id);

        public Task<bool> Delete(int id);

        public Task<bool> Update(int id, D oModel);

    }

}

