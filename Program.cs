// See https://aka.ms/new-console-template for more information
using ADONETCoreApp;

Console.WriteLine("Hello, World!");

Console.WriteLine("Please Enter ID to delete trainer");
int id = int.Parse(Console.ReadLine());
TrainerDB trainerDB = new TrainerDB();
bool status = trainerDB.DeleteTrainer(id);
if (status)
{
    Console.WriteLine($" ID : {id} Trainer Deleted ");
}
else
{
    Console.WriteLine($"Id : {id} Trainer not Found");
}

Console.ReadLine();