$dllPath = gi ".\src\RdStationApi.Client\bin\Release\RdStationApi.Client.dll";
$assembly = [System.Reflection.Assembly]::LoadFrom($dllPath);
$newVersion = $assembly.GetName().Version.ToString();
[xml]$nuspec = Get-Content .\nuget\RdStationApi.Client.nuspec;
$nuspec.package.metadata.version = $newVersion;
$file = gi ".\nuget\RdStationApi.Client.nuspec";
$nuspec.Save($file);