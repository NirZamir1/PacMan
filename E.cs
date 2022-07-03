using Timer = System.Timers.Timer;

namespace PacMan
{
    public class E : IEntity
    {
        int x;

        public event Action<XY, IEntity> MoveRequest;

        public XY Position { get; set; }

        public int Health { get; set; }
        public char Appearnace { get; set; }

        public E()
        {
            Position = new XY(10, 0);
            x = Position.X;
            Appearnace = 'E';
            Timer t = new Timer(500);
            t.Elapsed += callback;
            t.Start();
        }
        private void callback(object? sender, System.Timers.ElapsedEventArgs e)
        {
            x = Position.X;
            if (x > 0)
            {
                x--;
                MoveRequest?.Invoke(new XY( x, Position.Y ), this);
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
