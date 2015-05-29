call BatchMakeSource
cd ..\JustLogicBuildTest\Assets\JustLogic\Plugins
@if %errorlevel% neq 0 pause

rmdir Merged /S /Q
mkdir Merged
@if %errorlevel% neq 0 pause
..\..\..\..\deployscript\ILMerge /out:Merged\JustLogic.dll *.dll /lib:..\..\..\..\ /xmldocs /wildcards
@if %errorlevel% neq 0 pause

del *.dll
@if %errorlevel% neq 0 pause
del *.xml
@if %errorlevel% neq 0 pause
del *.pdb
@if %errorlevel% neq 0 pause
del *.mdb
@if %errorlevel% neq 0 pause

xcopy Merged\* Merged\.. /E /Y
@if %errorlevel% neq 0 pause
rmdir Merged /S /Q
@if %errorlevel% neq 0 pause

cd ..\..\..\..\deployscript\