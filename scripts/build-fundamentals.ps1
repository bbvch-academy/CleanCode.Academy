#
# build the solution using msbuild.
# Prerequirement: msbuild must be installed and available from path.
#
$scriptsDir = Split-Path $script:MyInvocation.MyCommand.Path
$projectFile = Join-Path -Path $scriptsDir -ChildPath "../source/Fundamentals/Fundamentals.csproj"

# for the msbuild arguments see:
# https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference?view=vs-2019
& msbuild $projectFile -verbosity:minimal -target:rebuild