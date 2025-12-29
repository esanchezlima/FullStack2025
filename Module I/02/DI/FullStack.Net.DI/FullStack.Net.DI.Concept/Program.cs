Console.WriteLine("Dependency Injection");
Console.WriteLine("====================");

DataStorageSQL dataStorageSQL = new DataStorageSQL();
DataStorageOracle dataStorageOracle = new DataStorageOracle();
DataStorageMongoDB dataStorageMongoDB = new DataStorageMongoDB();

Console.WriteLine();
Console.WriteLine("Obteniendo los datos sin inyeccion de dependencias");
Console.WriteLine("==================================================");
Console.WriteLine("Primer registro de SQL : " + dataStorageSQL.Get(1));
Console.WriteLine("Primer registro de Oracle : " + dataStorageOracle.Get(1));
Console.WriteLine("Primer registro de MongoDb : " + dataStorageMongoDB.Get(1));

ClientDIContructor clientDIContructor;
Console.WriteLine();
Console.WriteLine("Obteniendo los datos con inyeccion de dependencias (Constructor)");
Console.WriteLine("===============================================================");

clientDIContructor = new ClientDIContructor(new DataStorageSQL());
clientDIContructor.Insert("Alfredo Mendoza Fuentes (SQL)");
Console.WriteLine("El último registro de SQL : " + clientDIContructor.Get(clientDIContructor.Count));

clientDIContructor = new ClientDIContructor(new DataStorageOracle());
clientDIContructor.Insert("Alfredo Mendoza Fuentes (Oracle)");
clientDIContructor.Insert("Carlos Alonso Vargas (Oracle)");
Console.WriteLine("El último registro de Oracle : " + clientDIContructor.Get(clientDIContructor.Count));

clientDIContructor = new ClientDIContructor(new DataStorageMongoDB());
clientDIContructor.Insert("Alfredo Mendoza Fuentes (MongoDB)");
clientDIContructor.Insert("Carlos Alonso Vargas (MongoDB)");
clientDIContructor.Insert("Cristhian Alberto Caldas (MongoDB)");
Console.WriteLine("El último registro de MongoDB : " + clientDIContructor.Get(clientDIContructor.Count));

ClientDISetter clientDISetter = new ClientDISetter();
Console.WriteLine();
Console.WriteLine("Obteniendo los datos con inyeccion de dependencias (Setter)");
Console.WriteLine("===============================================================");

clientDISetter.DataStorage = new DataStorageSQL();
clientDISetter.Insert("Alfredo Mendoza Fuentes (SQL)");
Console.WriteLine("El último registro de SQL : " + clientDISetter.Get(clientDISetter.Count));

clientDISetter.DataStorage = new DataStorageOracle();
clientDISetter.Insert("Alfredo Mendoza Fuentes (Oracle)");
clientDISetter.Insert("Carlos Alonso Vargas (Oracle)");
Console.WriteLine("El último registro de SQL : " + clientDISetter.Get(clientDISetter.Count));

clientDISetter.DataStorage = new DataStorageMongoDB();
clientDISetter.Insert("Alfredo Mendoza Fuentes (MongoDB)");
clientDISetter.Insert("Carlos Alonso Vargas (MongoDB)");
clientDISetter.Insert("Cristhian Alberto Caldas (MongoDB)");
Console.WriteLine("El último registro de SQL : " + clientDISetter.Get(clientDISetter.Count));

ClientDIMethod clientDIMethod = new ClientDIMethod();
Console.WriteLine();
Console.WriteLine("Obteniendo los datos con inyeccion de dependencias (Method)");
Console.WriteLine("===============================================================");

clientDIMethod.Init(new DataStorageSQL());
clientDIMethod.Insert("Alfredo Mendoza Fuentes (SQL)");
Console.WriteLine("El último registro de SQL : " + clientDIMethod.Get(clientDIMethod.Count));

clientDIMethod.Init(new DataStorageOracle());
clientDIMethod.Insert("Alfredo Mendoza Fuentes (Oracle)");
clientDIMethod.Insert("Carlos Alonso Vargas (Oracle)");
Console.WriteLine("El último registro de SQL : " + clientDIMethod.Get(clientDIMethod.Count));

clientDIMethod.Init(new DataStorageMongoDB());
clientDIMethod.Insert("Alfredo Mendoza Fuentes (MongoDB)");
clientDIMethod.Insert("Carlos Alonso Vargas (MongoDB)");
clientDIMethod.Insert("Cristhian Alberto Caldas (MongoDB)");
Console.WriteLine("El último registro de SQL : " + clientDIMethod.Get(clientDIMethod.Count));

ServiceLocator serviceLocator = new ServiceLocator();
Console.WriteLine();
Console.WriteLine("Obteniendo los datos con inyeccion de dependencias (Service Locator)");
Console.WriteLine("===================================================================");
Console.WriteLine("Primer registro de SQL : " + serviceLocator.GetObject<DataStorageSQL>().Get(1));
Console.WriteLine("Primer registro de Oracle : " + serviceLocator.GetObject<DataStorageOracle>().Get(1));
Console.WriteLine("Primer registro de MongoDb : " + serviceLocator.GetObject<DataStorageMongoDB>().Get(1));


serviceLocator.Add<Person>(new Person("Erick", 39));
Person person01 = serviceLocator.GetObject<Person>();
Person person02 = serviceLocator.GetObject<Person>();
Person person03 = serviceLocator.GetObject<Person>();

Console.WriteLine($"person01 : {person01.Name}");
Console.WriteLine($"person02 : {person02.Name}");
Console.WriteLine($"person03 : {person03.Name}");
