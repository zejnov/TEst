using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SingleTon
{
    internal class ResourceAccessSimulator
    {
        private Timer _timer;
        //private PeopleRegister _peopleRegister;
        private PeopleRegisterSingleton _peopleRegister;

        public string SimulatorName { get; private set; }

        public delegate void EndOfSimulatorHandler(object sender, EndSimulatorArgs args);

        public event EndOfSimulatorHandler SimulationFinished;

        public ResourceAccessSimulator()
        {
            //_peopleRegister = new PeopleRegister();
            _peopleRegister = PeopleRegisterSingleton.GetInstance();

        }

        public void Simulate(int interval, int totalTime, string simulationName)
        {
            SimulatorName = simulationName;
            
            _timer = new Timer(interval);
            _timer.Elapsed += AddToRegister;

            var totalTimeTimer = new Timer(totalTime);
            totalTimeTimer.AutoReset = false;
            totalTimeTimer.Elapsed += StopTimers;
           
            _timer.Start();
            totalTimeTimer.Start();

        }

        private void StopTimers(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            OnSimulationFinished();
        }

        private void AddToRegister(object sender, ElapsedEventArgs e)
        {
            var dude = new Person()
            {
                Name = "Ktos",
                Surname = "Somebody",
            };
            
            _peopleRegister.Add(dude);
        }

        protected void OnSimulationFinished()
        {
            var  args = new EndSimulatorArgs()
            {
                SimulatorName = SimulatorName,
                Register = _peopleRegister.GetAll(),
            };

            if (SimulationFinished == null)
                return;

            SimulationFinished(this, args);
        }
    }
}
