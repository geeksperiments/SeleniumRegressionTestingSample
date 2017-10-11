# Automated Regression Testing

Starting Automated Regression Testing With XUnit, Selenium and Chrome.

## Setting up the project

To begin, we will create a blank solution to hold our test code. Open Visual studio and then go to **File** then **New** then **Project**:

![File, new project in visual studio](/docs/img/FileNewProject.png)

From the window that appears, go to **Other Project Types** then **Visual Studio Solutions** then pick **Blank Solution**. Set the **name** of the solution, the **location** on your machine it should be saved and press **OK**:

![Creating a blank solution in visual studio](/docs/img/CreateBlankSolution.png)

Right click on the solution in the solution explorer and go to **Add** then **New Solution Folder**, set the folder name to "*Test*":

![Create a solution folder in visual studio](/docs/img/NewSolutionFolder.png)

In the solution explorer, right click on the newly added solution folder and go to **Add** then **New Project**:

![Adding a new project to a solution in visual studio](/docs/img/AddNewProject.png)

From the window that appears, go to **Visual C#** then **Windows Classic Desktop** and go to **Class Library(.NET Framework)**. Set the **name** of the solution, and append */Test* to the **location**:

![Creating a new project in visual studio](/docs/img/CreateRegressionTestsClassLibrary.png)

## Installing packages

Now we need to add our dependencies using NuGet. Right click on the recently added project and go to **Manage NuGet Packages...**:

![Manage NuGet packages for a project in visual studio](/docs/img/ManageNuGetPackages.png)

From the window that appears, go to **Browse** then search for the following packages and install the latest version:

* xunit
* xunit.runner.visualstudio
* fluentassertions
* selenium.webdriver
* selenium.webdriver.chromedriver

![Installing NuGet packages in visual studio](/docs/img/AddNuGetPackages.png)

## Writing the first test

Firstly right click on the **Class1.cs** file already in your test project and go to **Rename**. Rename the file to something more appropriate:

![Rename a file in visual studio](/docs/img/RenameClass.png)

Open the file you recently renamed and inside the class add the following code:

```csharp
[Fact(DisplayName = "GIVEN the google homepage is open WHEN searching for new york times THEN results should appear")]
public void NewYorkTimesSearch()
{

}
```

This is the shell of our first test, however at the moment it will fail to compile. Although we have added the XUnit NuGet package, the class is currently unaware of it and we need to add a reference to it, the quickest way to do this is to put the cursor over **Fact** which should be underlined in red, then press `Ctrl + .` at the same time, this will bring up suggested fixes, select **using Xunit**:

![Suggested fixes in visual studio](/docs/img/AddMissingReference.png)

Next add the following code to your method and again use `Ctrl + .` to bring in any missing references:

```csharp
using (var driver = new ChromeDriver(@".\"))
{
    driver.Navigate().GoToUrl("https://www.google.co.uk/");
    driver.FindElementById("lst-ib").SendKeys("new york times");
    driver.FindElementById("lst-ib").Submit();

    var nytLink = driver.FindElementByLinkText("The New York Times - Breaking News, World News & Multimedia");
    nytLink.Should().NotBeNull();

    driver.Quit();
}
```

## Running the first test

If the test explorer isn't already visible, on the menu bar at the top of visual studio go to **Test** then **Windows** then **Test Explorer**:

![Showing the test explorer in visual studio](/docs/img/AddingTestExplorer.png)

Then we need to build the solution so the tests can be discovered. To do this, go to the menu bar at the top of visual studio and go to **Build** then **Build Solution**:

![Build Solution in visual studio](/docs/img/BuildSolution.png)

Finally in the test explorer pane, press **Run All**:

![Test xxplorer in visual studio](/docs/img/TestExplorer.png)