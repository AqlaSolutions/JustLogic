rmdir ..\JustLogicBuildTest\Assets\JustLogic\Editor\Code /S /Q
mkdir ..\JustLogicBuildTest\Assets\JustLogic\Editor\Code
@if %errorlevel% neq 0 pause
xcopy "..\Assets\JustLogicEditor\Editor" "..\JustLogicBuildTest\Assets\JustLogic\Editor\Code" /E
@if %errorlevel% neq 0 pause