// See https://aka.ms/new-console-template for more information
using POCNotifier;
using TableDependency.SqlClient;

const string _con = "Data Source=localhost;Initial Catalog=POCNotifier;Integrated Security=True;Pooling=False";

var service = new IncidentService();
service.StartService();

Console.WriteLine("Press a key to exit");
Console.WriteLine(Console.ReadKey().Key);