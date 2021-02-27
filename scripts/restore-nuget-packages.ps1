#
# Restores the NuGet packages of the solution.
#
$scriptsDir = Split-Path $script:MyInvocation.MyCommand.Path
$nuGetExe = Join-Path -Path $scriptsDir -ChildPath "tools/nuget.exe"
$solutionFile = Join-Path -Path $scriptsDir -ChildPath "../source/CleanCode.Academy.sln"

& $nuGetExe restore $solutionFile