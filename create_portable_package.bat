@echo off
echo ===============================================
echo  Creating Portable App Package
echo ===============================================
echo.

set "SOURCE_DIR=c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp\DesktopApp\bin\Release"
set "PACKAGE_DIR=c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp\PrinterDesktopApp_Portable"
set "ZIP_NAME=PrinterDesktopApp_Portable.zip"

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
cd /d "c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp"
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "DesktopApp\DesktopApp.csproj" /p:Configuration=Release /p:Platform="AnyCPU" /t:Build

if errorlevel 1 (
    echo Build failed!
    pause
    exit /b 1
)

echo Step 3: Creating package directory...
if exist "%PACKAGE_DIR%" rmdir /s /q "%PACKAGE_DIR%"
mkdir "%PACKAGE_DIR%"

echo Step 4: Copying application files...
xcopy "%SOURCE_DIR%\*.*" "%PACKAGE_DIR%\" /E /I /Y

echo Step 4.1: Copying Crystal Reports files...
if not exist "%PACKAGE_DIR%\CrystalReports" mkdir "%PACKAGE_DIR%\CrystalReports"
xcopy "DesktopApp\CrystalReports\*.rpt" "%PACKAGE_DIR%\CrystalReports\" /Y

echo Step 4.2: Copying additional Crystal Reports runtime components...
xcopy "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\crdb_*.dll" "%PACKAGE_DIR%\" /Y 2>nul
xcopy "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\crpe32.dll" "%PACKAGE_DIR%\" /Y 2>nul
xcopy "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\crqe.dll" "%PACKAGE_DIR%\" /Y 2>nul
xcopy "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\crtslv.dll" "%PACKAGE_DIR%\" /Y 2>nul

echo Step 5: Cleaning up unnecessary files...
del "%PACKAGE_DIR%\DesktopApp.application" 2>nul
del "%PACKAGE_DIR%\DesktopApp.exe.manifest" 2>nul
del "%PACKAGE_DIR%\*.pdb" 2>nul
del "%PACKAGE_DIR%\*.xml" 2>nul
if exist "%PACKAGE_DIR%\app.publish" rmdir /s /q "%PACKAGE_DIR%\app.publish"

echo Step 6: Creating README file...
(
echo ===============================================
echo  Printer Desktop App - Portable Version
echo ===============================================
echo.
echo INSTALLATION INSTRUCTIONS:
echo.
echo 1. Extract this ZIP file to any folder on your computer
echo 2. Run "DesktopApp.exe" to start the application
echo 3. Optionally, run "Install_Shortcuts.bat" to create desktop and start menu shortcuts
echo.
echo REQUIREMENTS:
echo - Windows 7 or later
echo - .NET Framework 4.8 or later
echo.
echo UNINSTALL:
echo Simply delete the extracted folder
echo.
echo For support, contact: [Your Contact Information]
echo.
) > "%PACKAGE_DIR%\README.txt"

echo Step 7: Creating shortcut installer...
(
echo @echo off
echo echo Creating shortcuts for Printer Desktop App...
echo.
echo set "APP_DIR=%%~dp0"
echo set "APP_EXE=%%APP_DIR%%DesktopApp.exe"
echo.
echo echo Creating desktop shortcut...
echo powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut([Environment]::GetFolderPath('Desktop'^) + '\Printer Desktop App.lnk'^); $Shortcut.TargetPath = '%%APP_EXE%%'; $Shortcut.WorkingDirectory = '%%APP_DIR%%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save(^)"
echo.
echo echo Creating start menu shortcut...
echo powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $StartMenuPath = [Environment]::GetFolderPath('StartMenu'^) + '\Programs'; if (-not (Test-Path $StartMenuPath^)^) { New-Item -ItemType Directory -Path $StartMenuPath -Force }; $Shortcut = $WshShell.CreateShortcut($StartMenuPath + '\Printer Desktop App.lnk'^); $Shortcut.TargetPath = '%%APP_EXE%%'; $Shortcut.WorkingDirectory = '%%APP_DIR%%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save(^)"
echo.
echo echo Shortcuts created successfully!
echo pause
) > "%PACKAGE_DIR%\Install_Shortcuts.bat"

echo Step 8: Creating ZIP package...
powershell -Command "Compress-Archive -Path '%PACKAGE_DIR%\*' -DestinationPath '%ZIP_NAME%' -Force"

if exist "%ZIP_NAME%" (
    echo.
    echo ===============================================
    echo  Portable package created successfully!
    echo ===============================================
    echo.
    echo Package location: %ZIP_NAME%
    echo Package contents: %PACKAGE_DIR%
    echo.
    echo You can now share this ZIP file with other users.
    echo They just need to extract it and run DesktopApp.exe
    echo.
) else (
    echo ERROR: Failed to create ZIP package
    echo You can manually ZIP the contents of: %PACKAGE_DIR%
)

pause
