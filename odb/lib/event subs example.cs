class Program
    {
        static void Main(string[] args)
        {

            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            m.Start();
            //Console.ReadKey();
        }
    }

    public class Metronome
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(Metronome m, EventArgs e);
        public void Start()
        {
            //while (true)
            //{
            //    System.Threading.Thread.Sleep(3000);
            //    if (Tick != null)
            //    {
            //        Tick(this, e);
            //    }
            //}
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Tik!");
                Tick?.Invoke(this, e);
            }
        }
    }

    public class Listener
    {
        public void Subscribe(Metronome m)
        {
            m.Tick += new Metronome.TickHandler(HeardIt);
        }
        private void HeardIt(Metronome m, EventArgs e)
        {
            System.Console.WriteLine("HEARD IT");
        }

    }