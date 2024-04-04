using BOFWorkFlowEngine.Core.WorkFlow;

var builder = new WorkFlowEngineBuilder().AddWorkFlowScheme("testCode");
var runTime = builder.Build();

var processId = Guid.NewGuid();
runTime.CreateProcessInstance(processId, "TestProcess", "testCode");

while (true)
{
    Console.WriteLine(runTime.CurrentProcessInstance.CurrentActivityName);
    Console.WriteLine("<======================>");

    var commands = runTime.CurrentProcessInstance.Commands;

    //commands?.ForEach(c => Console.WriteLine($"{c.Name}"));

    Console.Write("Enter command:");
    var index = Convert.ToInt32(Console.ReadLine().Trim());

    runTime.ExcecuteCommand(commands[index]);
}
