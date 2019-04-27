# FinalProject

4/27/2019

CURRENT ISSUE:
View count for threads is currently broken. It was working fine, but as I merged files something got messed up.

ALSO: When imported into visual studio and attempting to run, an error may pop up saying part of the file path is missing. Specifically, roslyn\csc.exe. To fix this, the Nuget Package Manger Console must be opened in visual studio and the command: 

Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r

must be ran.

