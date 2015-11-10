$dllPath = gi ".\src\RsStationApi\bin\Release\RsStationApi.dll";
$assembly = [System.Reflection.Assembly]::LoadFrom($dllPath);
$newVersion = $assembly.GetName().Version.ToString();
[xml]$nuspec = Get-Content .\nuget\RsStationApi.nuspec;
$nuspec.package.metadata.version = $newVersion;
$file = gi ".\nuget\RsStationApi.nuspec";
$nuspec.Save($file);