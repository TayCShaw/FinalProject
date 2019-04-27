# FinalProject
Built by Taylor Shaw and Samuel Riegler for our final project for CPS420: Web Applications Design.

This project is supposed to be a super small, scaled-down, basic feature version of a forum site. Users can register, post new threads, and reply to existing threads. The number of thread replies and views are displayed on the home page, where all of the threads that have been created can be seen.

Built in Visual Studio with ASP.NET and C#. It is not a very extensive project, but it was a fairly extensive learning experience.



If when attempting to run the project inside of Visual Studio an error stating that part of the file path is missing, specifically roslyn\csc.exe,shows up, a solution for us was to run this command in the Nuget Package Manager Console: 
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
--
