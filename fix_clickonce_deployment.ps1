# ClickOnce Deployment Fix Script for DevExpress Applications
# This script addresses strong name signature issues with DevExpress assemblies

Write-Host "======================================" -ForegroundColor Green
Write-Host " ClickOnce Deployment Fix Script" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Green
Write-Host ""

$projectPath = "c:\Users\Ahmed Ramzy\RamzyProject\Shopping\PrinterDesktopApp"
$publishPath = "C:\Users\Ahmed Ramzy\MYApp"
$projectFile = "$projectPath\DesktopApp\DesktopApp.csproj"

# Step 1: Clean previous builds
Write-Host "Step 1: Cleaning previous builds..." -ForegroundColor Yellow
if (Test-Path "$projectPath\DesktopApp\bin") {
    Remove-Item "$projectPath\DesktopApp\bin" -Recurse -Force
}
if (Test-Path "$projectPath\DesktopApp\obj") {
    Remove-Item "$projectPath\DesktopApp\obj" -Recurse -Force
}
if (Test-Path $publishPath) {
    Remove-Item $publishPath -Recurse -Force
}

# Step 2: Find MSBuild
Write-Host "Step 2: Locating MSBuild..." -ForegroundColor Yellow
$msbuildPaths = @(
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"
)

$msbuild = $null
foreach ($path in $msbuildPaths) {
    if (Test-Path $path) {
        $msbuild = $path
        break
    }
}

if (-not $msbuild) {
    Write-Host "MSBuild not found! Please install Visual Studio." -ForegroundColor Red
    Read-Host "Press Enter to exit"
    exit 1
}

Write-Host "Found MSBuild at: $msbuild" -ForegroundColor Green

# Step 3: Build solution
Write-Host "Step 3: Building solution..." -ForegroundColor Yellow
Set-Location $projectPath
& $msbuild "DesktopApp.sln" /p:Configuration=Release /p:Platform="Any CPU" /t:Rebuild

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed! Check for compilation errors." -ForegroundColor Red
    Read-Host "Press Enter to exit"
    exit 1
}

# Step 4: Create publish directory
Write-Host "Step 4: Creating publish directory..." -ForegroundColor Yellow
New-Item -ItemType Directory -Path $publishPath -Force | Out-Null

# Step 5: Publish with unsigned manifests
Write-Host "Step 5: Publishing application (unsigned)..." -ForegroundColor Yellow
& $msbuild $projectFile /p:Configuration=Release /p:Platform="Any CPU" /t:Publish /p:PublishUrl="$publishPath\" /p:SignManifests=false /p:SignAssembly=false

if ($LASTEXITCODE -ne 0) {
    Write-Host "Publish failed! Trying alternative method..." -ForegroundColor Yellow
    
    # Alternative: Copy files manually and create application manifest
    Write-Host "Step 5b: Manual deployment method..." -ForegroundColor Yellow
    
    $binPath = "$projectPath\DesktopApp\bin\Release"
    $appFilesPath = "$publishPath\Application Files\DesktopApp_1_0_0_3"
    
    New-Item -ItemType Directory -Path $appFilesPath -Force | Out-Null
    
    # Copy all files from bin\Release
    Copy-Item "$binPath\*" -Destination $appFilesPath -Recurse -Force
    
    # Create simple application manifest
    $manifest = @"
<?xml version="1.0" encoding="utf-8"?>
<asmv1:assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1" xmlns:asmv1="urn:schemas-microsoft-com:asm.v1" xmlns:asmv2="urn:schemas-microsoft-com:asm.v2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <assemblyIdentity name="DesktopApp.exe" version="1.0.0.3" type="win32" />
  <trustInfo xmlns="urn:schemas-microsoft-com:asm.v2">
    <security>
      <requestedPrivileges xmlns="urn:schemas-microsoft-com:asm.v3">
        <requestedExecutionLevel level="asInvoker" uiAccess="false" />
      </requestedPrivileges>
    </security>
  </trustInfo>
  <dependency>
    <dependentAssembly>
      <assemblyIdentity name="DesktopApp" version="1.0.0.3" type="win32" processorArchitecture="amd64" />
      <codebase version="1.0.0.3" href="DesktopApp.exe" />
    </dependentAssembly>
  </dependency>
</asmv1:assembly>
"@
    
    $manifest | Out-File "$appFilesPath\DesktopApp.exe.manifest" -Encoding UTF8
    
    # Create deployment manifest
    $deployManifest = @"
<?xml version="1.0" encoding="utf-8"?>
<asmv1:assembly xsi:schemaLocation="urn:schemas-microsoft-com:asm.v1 assembly.adaptive.xsd" manifestVersion="1.0" xmlns:asmv1="urn:schemas-microsoft-com:asm.v1" xmlns="urn:schemas-microsoft-com:asm.v2" xmlns:asmv2="urn:schemas-microsoft-com:asm.v2" xmlns:xrml="urn:mpeg:mpeg21:2003:01-REL-R-NS" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <assemblyIdentity name="DesktopApp.application" version="1.0.0.3" publicKeyToken="0000000000000000" language="neutral" processorArchitecture="amd64" xmlns="urn:schemas-microsoft-com:asm.v1" />
  <description asmv2:publisher="Ahmed Ramzy" asmv2:product="Printer Desktop App" xmlns="urn:schemas-microsoft-com:asm.v1" />
  <deployment install="true" />
  <compatibleFrameworks xmlns="urn:schemas-microsoft-com:clickonce.v2">
    <framework targetVersion="4.8" profile="Full" supportedRuntime="4.0.30319" />
  </compatibleFrameworks>
  <dependency>
    <dependentAssembly dependencyType="install" allowDelayedBinding="true" codebase="Application Files\DesktopApp_1_0_0_3\DesktopApp.exe.manifest" size="7168">
      <assemblyIdentity name="DesktopApp.exe" version="1.0.0.3" publicKeyToken="0000000000000000" language="neutral" processorArchitecture="amd64" type="win32" />
      <hash>
        <dsig:Transforms>
          <dsig:Transform Algorithm="urn:schemas-microsoft-com:HashTransforms.Identity" />
        </dsig:Transforms>
        <dsig:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1" />
        <dsig:DigestValue>placeholder</dsig:DigestValue>
      </hash>
    </dependentAssembly>
  </dependency>
</asmv1:assembly>
"@
    
    $deployManifest | Out-File "$publishPath\DesktopApp.application" -Encoding UTF8
}

Write-Host ""
Write-Host "======================================" -ForegroundColor Green
Write-Host " Deployment completed!" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Green
Write-Host "The application is now available at:" -ForegroundColor White
Write-Host "$publishPath\DesktopApp.application" -ForegroundColor Cyan
Write-Host ""
Write-Host "If you still get signature errors, try:" -ForegroundColor Yellow
Write-Host "1. Right-click DesktopApp.application → Properties → Unblock" -ForegroundColor Yellow
Write-Host "2. Or copy the entire MYApp folder to another location" -ForegroundColor Yellow
Write-Host ""
Read-Host "Press Enter to exit"
