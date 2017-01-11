param($installPath, $toolsPath, $package, $project)

$files = Join-Path $toolsPath '..\content\' | Get-ChildItem -Recurse
foreach ($file in $files) 
{

$project.ProjectItems.Item($file.Name).Delete()
$project.ProjectItems.AddFromFile($file.FullName);
$pi = $project.ProjectItems.Item($file.Name);
$pi.Properties.Item("BuildAction").Value = [int]2;
$pi.Properties.Item("CopyToOutputDirectory").Value = [int]2;

}
