@echo off
echo ======================================
echo  ClickOnce Deployment Fix Script
echo ======================================
echo.

echo Step 1: Cleaning previous builds...
cd /d "c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp"
rmdir /s /q "DesktopApp\bin" 2>nul
rmdir /s /q "DesktopApp\obj" 2>nul
rmdir /s /q "C:\Users\Ahmed Ramzy\MYApp" 2>nul

echo Step 2: Rebuilding solution...
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" "DesktopApp.sln" /p:Configuration=Release /p:Platform="Any CPU" /t:Rebuild

if errorlevel 1 (
    echo Build failed! Check for compilation errors.
    pause
    exit /b 1
)

echo Step 3: Publishing application...
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" "DesktopApp\DesktopApp.csproj" /p:Configuration=Release /p:Platform="Any CPU" /t:Publish /p:PublishUrl="C:\Users\Ahmed Ramzy\MYApp\"

if errorlevel 1 (
    echo Publish failed! Check the error messages above.
    pause
    exit /b 1
)

echo.
echo ======================================
echo  Deployment completed successfully!
echo ======================================
echo The application is now available at:
echo C:\Users\Ahmed Ramzy\MYApp\DesktopApp.application
echo.
pause
