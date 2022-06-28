using Timer = System.Timers.Timer;

namespace PacMan
{
    public class E : IEntity
    {
        int x;

        public event Action<int[], IEntity> MoveRequest;

        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public char Appearnace { get; set; }

        public E()
        {
            X = 10;
            x = X;
            Y = 0;
            Appearnace = 'E';
            Timer t = new Timer(500);
            t.Elapsed += callback;
            t.Start();
        }
        private void callback(object? sender, System.Timers.ElapsedEventArgs e)
        {
            x = X;
            if (x > 0)
            {
                x--;
                MoveRequest?.Invoke(new int[] { x, Y }, this);
            }
        }

       
        public void innit()
        {
            Timer t = new Timer(1000);
            t.Elapsed += callback;
            t.Start();
        }
    }
}
