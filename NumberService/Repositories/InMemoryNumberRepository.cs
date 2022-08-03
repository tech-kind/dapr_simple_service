namespace CounterService.Repositories
{
    public class InMemoryNumberRepository : INumberRepository
    {
        private Random _rnd;

        public InMemoryNumberRepository()
        {
            _rnd = new Random();
        }

        public int GetNumber()
        {
            return _rnd.Next(0, 100);
        }
    }
}
