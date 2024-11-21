namespace WebMiddleware.Services
{
    public class CounterImpl : ICounter
    {
        private int counter = 0;
        public int Get() => counter;

        //public void Increment() => counter++;
        public void Increment() { 
            lock (this) { counter++; }
        }
    }
}
