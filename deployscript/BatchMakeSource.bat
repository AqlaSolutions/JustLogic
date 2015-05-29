rmdir ..\JustLogicUnitsSource /S /Q
mkdir ..\JustLogicUnitsSource
@if %errorlevel% neq 0 pause
mkdir ..\JustLogicUnitsSource\Plugins
@if %errorlevel% neq 0 pause

cd ..\JustLogicBuildTest\Assets\JustLogic\Plugins
@if %errorlevel% neq 0 pause
copy JustLogic.dll ..\..\..\..\JustLogicUnitsSource\Plugins /Y
@if %errorlevel% neq 0 pause
copy JustLogic.xml ..\..\..\..\JustLogicUnitsSource\Plugins /Y
copy JustLogic.pdb ..\..\..\..\JustLogicUnitsSource\Plugins /Y
copy JustLogic.mdb ..\..\..\..\JustLogicUnitsSource\Plugins /Y

cd ..\..\..\..\deployscript\
@if %errorlevel% neq 0 pause

xcopy ..\Assets\JustLogicUnits ..\JustLogicUnitsSource /E
@if %errorlevel% neq 0 pause

del ..\JustLogicUnitsSourceCode.zip
zip -r ..\JustLogicUnitsSourceCode.zip ..\JustLogicUnitsSource
@if %errorlevel% neq 0 pause

move /Y ..\JustLogicUnitsSourceCode.zip ..\JustLogicBuildTest\Assets\JustLogic\SourceCode
@if %errorlevel% neq 0 pause

rmdir ..\JustLogicUnitsSource /S /Q
@if %errorlevel% neq 0 pause