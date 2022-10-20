using System.Configuration;
using System.ServiceProcess;

namespace POCNotifier
{
    public partial class IncidentService : ServiceBase
    {
        private readonly IncidentRepository IncidentRepository;

        public IncidentService()
        {
            IncidentRepository = new IncidentRepository();
            IncidentRepository.OnNewIncident += MessageRepository_OnNewIncident;
        }

        private void MessageRepository_OnNewIncident(Incident incident)
        {
            Console.WriteLine($"{incident.Id}\t{incident.Description}");
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Issues service started");
            new Thread(StartService).Start();
        }

        internal void StartService()
        {
            Task.Run(() =>
            {
                IncidentRepository.Start("Data Source=localhost;Initial Catalog=POCNotifier;Integrated Security=True;Pooling=False");
            });
        }
    }
}
