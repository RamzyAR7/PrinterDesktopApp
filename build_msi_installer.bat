@echo off
echo ===============================================
echo  Building MSI Installer
echo ===============================================
echo.

REM Check if WiX is installed
where candle.exe >nul 2>&1
if errorlevel 1 (
    echo ERROR: WiX Toolset not found!
    echo.
    echo Please install WiX Toolset from: https://wixtoolset.org/
    echo After installation, add WiX bin directory to your PATH
    echo Typical location: C:\Program Files (x86)\WiX Toolset v3.11\bin
    echo.
    pause
    exit /b 1
)

echo Step 1: Building application in Release mode...
cd /d "c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp"
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "DesktopApp\DesktopApp.csproj" /p:Configuration=Release /p:Platform="AnyCPU" /t:Build

if errorlevel 1 (
    echo Build failed!
    pause
    exit /b 1
)

echo Step 2: Compiling WiX source...
candle.exe Installer.wxs -out Installer.wixobj

if errorlevel 1 (
    echo WiX compilation failed!
    pause
    exit /b 1
)

echo Step 3: Linking MSI package...
light.exe Installer.wixobj -out PrinterDesktopApp_Installer.msi -ext WixUIExtension

if errorlevel 1 (
    echo MSI linking failed!
    pause
    exit /b 1
)

echo Step 4: Cleaning up temporary files...
del Installer.wixobj 2>nul
del *.wixpdb 2>nul

if exist "PrinterDesktopApp_Installer.msi" (
    echo.
    echo ===============================================
    echo  MSI Installer created successfully!
    echo ===============================================
    echo.
    echo Installer file: PrinterDesktopApp_Installer.msi
    echo.
    echo You can now share this MSI file with other users.
    echo They can double-click it to install the application.
    echo.
) else (
    echo ERROR: MSI creation failed
)

pause
