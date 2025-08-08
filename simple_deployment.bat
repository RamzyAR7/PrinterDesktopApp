@echo off
echo ===============================================
echo  Simple XCOPY Deployment (No ClickOnce)
echo ===============================================
echo.

set "SOURCE_DIR=c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp\DesktopApp\bin\Release"
set "DEST_DIR=C:\Users\Ahmed Ramzy\MySimpleApp"

echo Step 1: Checking for required dependencies...
cd /d "c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp"
if not exist "DesktopApp\bin\Release\log4net.dll" (
    echo log4net.dll not found. This is required for Crystal Reports.
    echo Copying log4net.dll to Release directory...
    if exist "DesktopApp\log4net.dll" (
        copy "DesktopApp\log4net.dll" "DesktopApp\bin\Release\"
    ) else (
        echo ERROR: log4net.dll not found in project directory.
        echo Please ensure log4net.dll is available for Crystal Reports.
        pause
        exit /b 1
    )
)

if not exist "DesktopApp\bin\Release\CrystalDecisions.Web.dll" (
    echo CrystalDecisions.Web.dll not found. This is required for Crystal Reports.
    echo Copying CrystalDecisions.Web.dll to Release directory...
    if exist "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\dotnet\CrystalDecisions.Web.dll" (
        copy "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\dotnet\CrystalDecisions.Web.dll" "DesktopApp\bin\Release\"
    ) else (
        echo ERROR: CrystalDecisions.Web.dll not found in Crystal Reports installation.
        echo Please ensure Crystal Reports is properly installed.
        pause
        exit /b 1
    )
)

echo Step 2: Building application in Release mode...
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "DesktopApp\DesktopApp.csproj" /p:Configuration=Release /p:Platform="AnyCPU" /t:Build

if errorlevel 1 (
    echo Build failed!
    pause
    exit /b 1
)

echo Step 3: Cleaning destination directory...
if exist "%DEST_DIR%" rmdir /s /q "%DEST_DIR%"
mkdir "%DEST_DIR%"

echo Step 4: Copying application files...
xcopy "%SOURCE_DIR%\*.*" "%DEST_DIR%\" /E /I /Y

echo Step 5: Cleaning up ClickOnce files...
del "%DEST_DIR%\DesktopApp.application" 2>nul
del "%DEST_DIR%\DesktopApp.exe.manifest" 2>nul
if exist "%DEST_DIR%\app.publish" rmdir /s /q "%DEST_DIR%\app.publish"

echo Step 6: Creating desktop shortcut...
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut([Environment]::GetFolderPath('Desktop') + '\Printer Desktop App.lnk'); $Shortcut.TargetPath = '%DEST_DIR%\DesktopApp.exe'; $Shortcut.WorkingDirectory = '%DEST_DIR%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save()"

echo.
echo ===============================================
echo  Deployment completed successfully!
echo ===============================================
echo.
echo Your application is ready at:
echo %DEST_DIR%\DesktopApp.exe
echo.
echo A desktop shortcut has been created.
echo.
pause
