del ..\JustLogicBuildTest\Assets\JustLogic\Plugins\*.dll
del ..\JustLogicBuildTest\Assets\JustLogic\Plugins\*.xml
del ..\JustLogicBuildTest\Assets\JustLogic\Plugins\*.pdb
del ..\JustLogicBuildTest\Assets\JustLogic\Plugins\*.mdb
del ..\JustLogicBuildTest\Assets\JustLogic\Editor\*.dll

cd ..
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "deployscript\JustLogicBuild.sln" /t:Clean,Build /p:Configuration=Release

@if %errorlevel% neq 0 pause
cd deployscript
