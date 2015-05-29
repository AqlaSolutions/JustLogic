rmdir ..\JustLogicBuildTest\Assets\JustLogic\Plugins\Code /S /Q
mkdir ..\JustLogicBuildTest\Assets\JustLogic\Plugins\Code
@if %errorlevel% neq 0 pause
xcopy "..\Assets\JustLogicCode" "..\JustLogicBuildTest\Assets\JustLogic\Plugins\Code" /E
@if %errorlevel% neq 0 pause
copy "..\APIDocs\Help\JustLogicApiDocs.chm" "..\JustLogicBuildTest\Assets\JustLogic" /Y
@if %errorlevel% neq 0 pause
