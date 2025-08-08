@echo off
echo Creating shortcuts for Printer Desktop App...

set "APP_DIR=%~dp0"
set "APP_EXE=%APP_DIR%DesktopApp.exe"

echo Creating desktop shortcut...
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut([Environment]::GetFolderPath('Desktop'^) + '\Printer Desktop App.lnk'^); $Shortcut.TargetPath = '%APP_EXE%'; $Shortcut.WorkingDirectory = '%APP_DIR%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save(^)"

echo Creating start menu shortcut...
powershell -Command "$WshShell = New-Object -comObject WScript.Shell; $StartMenuPath = [Environment]::GetFolderPath('StartMenu'^) + '\Programs'; if (-not (Test-Path $StartMenuPath^)^) { New-Item -ItemType Directory -Path $StartMenuPath -Force }; $Shortcut = $WshShell.CreateShortcut($StartMenuPath + '\Printer Desktop App.lnk'^); $Shortcut.TargetPath = '%APP_EXE%'; $Shortcut.WorkingDirectory = '%APP_DIR%'; $Shortcut.Description = 'Printer Desktop Application'; $Shortcut.Save(^)"

echo Shortcuts created successfully!
pause
