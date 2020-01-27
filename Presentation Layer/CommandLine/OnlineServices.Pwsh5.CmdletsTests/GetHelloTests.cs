using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Pwsh5.Cmdlets;

namespace OnlineServices.Pwsh5.CmdletsTests
{
    [TestClass]
    public class GetHelloTests
    {
        [TestMethod]
        public void GetHello_ShowsHelloName_WhenNameIsProvided()
        {
            var initialSessionState = InitialSessionState.CreateDefault();

            initialSessionState.Commands.Add(new SessionStateCmdletEntry("Get-Hello", typeof(GetHello), null));

            using(var runspace =  RunspaceFactory.CreateRunspace(initialSessionState))
            {
                runspace.Open();

                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = runspace;

                    //Tests Here
                    //ARRANGE
                    var pwshCommand = new Command("Get-Hello");
                    pwshCommand.Parameters.Add("Name", "John");

                    powershell.Commands.AddCommand(pwshCommand);
                    //ACT
                    var results = powershell.Invoke();

                    //ASSERT
                    Assert.AreEqual(1, results.Count);

                }

            }
        }

        [TestMethod]
        public void GetHello_ShowsHelloName_WhenNameIsProvidedInPipeline()
        {
            var initialSessionState = InitialSessionState.CreateDefault();

            initialSessionState.Commands.Add(new SessionStateCmdletEntry("Get-Hello", typeof(GetHello), null));

            using (var runspace = RunspaceFactory.CreateRunspace(initialSessionState))
            {
                runspace.Open();

                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = runspace;

                    //Tests Here
                    //ARRANGE
                    powershell.Commands.AddCommand("Get-Hello");

                    //ACT
                    var results = powershell.Invoke<string>(new[] { "Nathan", "John", "", "Maria"});

                    //ASSERT
                    Assert.AreEqual(4, results.Count);
                    Assert.AreEqual("Hello, Nathan!", results[0].ToString());
                    Assert.AreEqual("Hello, John!", results[1].ToString());
                    Assert.AreEqual("Hello, World!", results[2].ToString());
                    Assert.AreEqual("Hello, Maria!", results[3].ToString());

                }

            }
        }
    }
}
