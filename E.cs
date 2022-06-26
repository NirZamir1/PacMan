using Timer = System.Timers.Timer;

namespace PacMan
{
    public class E : LivingEntity
    {
        int x;
        public E()
        {
            _x = 10;
            x = _x;
            _y = 0;
            Appearnace = 'E';
            Timer t = new Timer(500);
            t.Elapsed += callback;
            t.Start();
        }
        private void callback(object? sender, System.Timers.ElapsedEventArgs e)
        {
            x = _x;
            if(_x>0)
            x--;
        }

        public override int[] Do()
        {  
            return new int[] { x, _y };
        }
    }
}
