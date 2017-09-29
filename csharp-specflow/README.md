Web and Mobile Application Test Automation Project

This project is written in C# and utilizes NUnit as the test runner, SpecFlow for defining and executing test cases, Selenium for interacting with web browsers and Appium for interacting with mobile devices/emulators, and Extent Reports for reporting the test results.

Open this project in Visual Studio. If you right-click on the project (CSharpSpecflow) and choose Manage NuGet Packages you will see all the dependencies are bundled into this project for you (visible in packages.config).

For running web browser tests:
	You need the browser that you want to test against installed (Chrome by default)

For running mobile tests (Android):
	Dependencies:

		Download and install the latest Java JDK - http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html
			Add JAVA_HOME to your environment variables, pointing to the JDK installation folder
			Add an entry on your PATH for the bin folder under the JDK installation folder
	
		Download and install Android Studio, which will get you Android SDK and Android Emulators - https://developer.android.com/studio/index.html
			Add ANDROID_HOME to your environment variables, pointing to your Android SDK installation folder
			Add an entry on your PATH for the tools folder under the Android SDK installation folder
			Add an entry on your PATH for the platform-tools folder under the Android SDK installation folder

		Download and install Apache Ant - http://ant.apache.org/bindownload.cgi
			Add an entry on your PATH for the bin folder under the Apache Ant installation folder

		Download and install Apache Maven - http://maven.apache.org/download.cgi
			Add M2 to your environment variables, pointing to the bin folder under the Apache Maven installation folder
			Add M2_HOME to your environment variables, pointing to the Apache Maven installation folder
			Add an entry on your PATH for the bin folder under the Apache Maven installation folder

		Download Appium Desktop, which will get you Appium Server and Appium Inspector (for inspecting elements on mobile devices)

	Execute:
		Open Android Studio and click Tools -> Android -> AVD Manager (if this is the first time opening Android Studio, create a new project - you won't actually be using it but it loads the entire Android Studio)
			Create Virtual Device -> choose from any of the available options
			Click the start/run button to start up the emulator - it will take a couple of minutes to boot up the device
			
		Open Appium and click Start Server (leave host and port as is)
			If you want to use the Inspector *do not do this at the same time you're running tests* (i.e. while writing test cases to find the element locators), click on the magnifying glass icon *after the emulator is loaded*
				Set the following Desired Capabilities (and Save them and then start session):
					platformName: Android
					platformVersion: <whatever target version you chose for your emulator> (i.e. 7.1.1)
					deviceName: Android Emulator
					app: <the absolute path to your app's .apk file> (if you want a sample one to work with download the Calculator_2.0.apk from https://github.com/testobject/calculator-test-gradle)
				This will bring up a window that displays a copy of the emulator view plus the App Source and a panel that shows details of the selected element


For executing tests:
	First, build the project (F6)

	Keep in mind for mobile tests, Appium Server and an emulator (that matches the desired capabilities from SetupAndTeardownSteps.cs) must be running.

	There are a few methods for running tests:
		From within Visual Studio (typical for running tests locally):
			If you want to run all tests from a feature file, right-click the feature file and choose Run SpecFlow Scenarios
			If you want to run 1 or more selected tests, open the Test Explorer view and select the test(s) you want and right-click and choose Run Selected Tests
			If you want to run all tests in the project, open the Test Explorer view and click Run All

		From the command line, from project directory, i.e. C:\Source\csharp-specflow (more typical from build machine than local):
			Open Command Prompt
			cd packages\NUnit.ConsoleRunner.3.7.0\tools
			Run all the tests with this command:
				nunit3-console.exe ..\..\..\csharp-specflow\bin\Debug\CSharpSpecflow.dll
			To run only tests with a specific tag, use the where parameter (i.e. run only web tests):
				nunit3-console.exe ..\..\..\csharp-specflow\bin\Debug\CSharpSpecflow.dll --where:cat==web
					Note, if you open up web.feature.cs, you'll see a line like this, which is where the 'cat' value comes from: [NUnit.Framework.CategoryAttribute("web")]
			If you'd like to see which tests would run without actually running them (note you can apply other parameters here to filter list, such as where):
				nunit3-console.exe ..\..\..\csharp-specflow\bin\Debug\CSharpSpecflow.dll --explore
			To run 1 or more selected tests (comma-separated) - get the full names from the command above - note, do not provide parameterized values:
				nunit3-console.exe ..\..\..\csharp-specflow\bin\Debug\CSharpSpecflow.dll --test=CSharpSpecflow.Features.SampleFeatureForWebApplicationsFeature.TooltipScenario,CSharpSpecflow.Features.SampleFeatureForWebApplicationsFeature.TestScenario
			To run 1 or more selected tests repeatably (i.e. smoke tests, functional tests):
				create a text file with the list of tests to run, one per line, then pass the txt path
				nunit3-console.exe ..\..\..\csharp-specflow\bin\Debug\CSharpSpecflow.dll --testlist=..\..\..\CSharpSpecflow\smoketests.txt
				
		Command-line arguments (--params=<argumentName1>=<argumentValue1>;<argumentName2>=<argumentValue2>)
			browser: chrome (default if none is supplied), firefox, ie
			remoteDriverUrl: http://127.0.0.1:4723/wd/hub (default if none is supplied)
			emulatorVersion: 7.1.1 (no default; will grab whichever emulator version is available)
			apkPath: C:\\Users\\cduggan\\Downloads\\Calculator_2.0.apk (defaults if none is supplied)