@echo off
echo ===============================================
echo  Printer Desktop App - Setup for Other PC
echo ===============================================
echo.

REM Get the directory where this script is located
set "SCRIPT_DIR=%~dp0"
set "SOURCE_DIR=%SCRIPT_DIR%DesktopApp\bin\Release"

REM Let user choose installation directory
set "DEFAULT_DIR=C:\Program Files\Printer Desktop App"
echo Default installation directory: %DEFAULT_DIR%
set /p "DEST_DIR=Enter installation directory (or press Enter for default): "
if "%DEST_DIR%"=="" set "DEST_DIR=%DEFAULT_DIR%"

echo.
echo Installing to: %DEST_DIR%
echo.

REM Check if source files exist
if not exist "%SOURCE_DIR%\DesktopApp.exe" (
    echo ERROR: Application files not found!
    echo Please make sure this setup is run from the project directory.
    echo Expected location: %SOURCE_DIR%
    pause
    exit /b 1
)

echo Step 1: Creating installation directory...
if not exist "%DEST_DIR%" mkdir "%DEST_DIR%"

echo Step 2: Copying application files...
xcopy "%SOURCE_DIR%\*.*" "%DEST_DIR%\" /E /I /Y

if errorlevel 1 (
    echo ERROR: Failed to copy files. You may need to run as Administrator.
    pause
    exit /b 1
)

echo Step 3: Cleaning up unnecessary files...
del "%DEST_DIR%\DesktopApp.application" 2>nul
del "%DEST_DIR%\DesktopApp.exe.manifest" 2>nul
del "%DEST_DIR%\*.pdb" 2>nul
del "%DEST_DIR%\*.xml" 2>nul
if exist "%DEST_DIR%\app.publish" rmdir /s /q "%DEST_DIR%\app.publish"

echo Step 4: Creating desktop shortcut...
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut([Environment]::GetFolderPath('Desktop') + '\Printer Desktop App.lnk'); $Shortcut.TargetPath = '%DEST_DIR%\DesktopApp.exe'; $Shortcut.WorkingDirectory = '%DEST_DIR%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save()"

echo Step 5: Creating Start Menu shortcut...
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $StartMenuPath = [Environment]::GetFolderPath('StartMenu') + '\Programs'; if (-not (Test-Path $StartMenuPath)) { New-Item -ItemType Directory -Path $StartMenuPath -Force }; $Shortcut = $WshShell.CreateShortcut($StartMenuPath + '\Printer Desktop App.lnk'); $Shortcut.TargetPath = '%DEST_DIR%\DesktopApp.exe'; $Shortcut.WorkingDirectory = '%DEST_DIR%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save()"

echo Step 6: Creating uninstaller...
(
echo @echo off
echo echo Uninstalling Printer Desktop App...
echo.
echo Removing shortcuts...
echo del "%%USERPROFILE%%\Desktop\Printer Desktop App.lnk" 2^>nul
echo del "%%APPDATA%%\Microsoft\Windows\Start Menu\Programs\Printer Desktop App.lnk" 2^>nul
echo.
echo Removing application files...
echo rmdir /s /q "%DEST_DIR%"
echo.
echo Uninstallation complete!
echo pause
) > "%DEST_DIR%\Uninstall.bat"

echo.
echo ===============================================
echo  Installation completed successfully!
echo ===============================================
echo.
echo Installation location: %DEST_DIR%
echo.
echo Shortcuts created:
echo - Desktop: Printer Desktop App
echo - Start Menu: Printer Desktop App
echo.
echo To uninstall, run: %DEST_DIR%\Uninstall.bat
echo.
pause
