
rd /s /q ..\docroot
md ..\docroot
xcopy /E /I /Y .\dist\* ..\docroot
rd /s /q ..\VHActorManager\bin\Debug\net7.0-windows\docroot
md ..\VHActorManager\bin\Debug\net7.0-windows\docroot
xcopy /E /I /Y .\dist\* ..\VHActorManager\bin\Debug\net7.0-windows\docroot
rd /s /q ..\VHActorManager\bin\Release\net7.0-windows\docroot
md ..\VHActorManager\bin\Release\net7.0-windows\docroot
xcopy /E /I /Y .\dist\* ..\VHActorManager\bin\Release\net7.0-windows\docroot
