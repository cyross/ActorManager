
rd /s /q ..\docroot
md ..\docroot
xcopy /E /I /Y .\dist\* ..\docroot
