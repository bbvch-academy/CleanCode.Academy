#
# build the solution using msbuild.
# Prerequirement: msbuild must be installed and available from path.
#
$scriptsDir = Split-Path $script:MyInvocation.MyCommand.Path
$solutionFile = Join-Path -Path $scriptsDir -ChildPath "../source/CleanCode.Academy.sln"

# for the msbuild arguments see:
# https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference?view=vs-2019
& msbuild $solutionFile -verbosity:minimal