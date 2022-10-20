using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace POCNotifier
{
    public delegate void NewIncidentHandler(Incident incident);

    public class IncidentRepository : IDisposable
    {
        private SqlTableDependency<Incident>? sqlTableDependency;

        public void Start(string connectionString)
        {
            sqlTableDependency = new SqlTableDependency<Incident>(connectionString);
            sqlTableDependency.OnChanged += HandleOnChanged;
            sqlTableDependency.Start();
        }
        public event NewIncidentHandler? OnNewIncident;
        private void HandleOnChanged(object sender, RecordChangedEventArgs<Incident> e)
        {
            if (e.ChangeType == TableDependency.SqlClient.Base.Enums.ChangeType.Insert)
            {
                OnNewIncident?.Invoke(e.Entity);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && sqlTableDependency != null)
                {
                    sqlTableDependency.Stop();
                    sqlTableDependency.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
