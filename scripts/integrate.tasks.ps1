# <copyright file="integrate.ps1" company="bbv Software Services AG">
#   Copyright (c) 2014
#   
#   Licensed under the Apache License, Version 2.0 (the "License");
#   you may not use this file except in compliance with the License.
#   You may obtain a copy of the License at
#   
#   http://www.apache.org/licenses/LICENSE-2.0
#   
#   Unless required by applicable law or agreed to in writing, software
#   distributed under the License is distributed on an "AS IS" BASIS,
#   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#   See the License for the specific language governing permissions and
#   limitations under the License.
# </copyright>

$rootDir = Resolve-Path ..
$solutionFile = "$rootDir\source\CleanCode.Academy.sln"
$resultsDir = "$rootDir\result"
$nunitRunner = "$rootDir\source\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe"

Properties {
    $configuration = "Release"
    $binDir = "$resultsDir\$configuration"
}

Task Integrate -depends Build, UnitTests

Task Build {
    Exec { msbuild $solutionFile /target:Build /property:Configuration=release /verbosity:minimal }
}

Task UnitTests {
    $testAssemblies = Get-ChildItem $binDir -Recurse -Include "*Test*.dll" |
                      Foreach-Object {
                          $_.Fullname
                      }
    Exec { & $nunitRunner $testAssemblies "/noshadow" "/framework=net-4.5" "/xml=$resultsDir\CleanCode.Tests.xml" }
}