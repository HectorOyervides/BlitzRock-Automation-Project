param($installPath, $toolsPath, $package, $project)

$files = Join-Path $toolsPath '..\content\' | Get-ChildItem -Recurse
foreach ($file in $files) 
{

$project.ProjectItems.Item($file.Name).Delete()

}