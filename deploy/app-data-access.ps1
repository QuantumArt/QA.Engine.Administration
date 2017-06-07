param(
[string] $siteName = "qp"
)


# restart as admin
If (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
{   
    $arguments = "-noexit & '" + $myinvocation.mycommand.definition + "'"
    Start-Process powershell -Verb runAs -ArgumentList $arguments
    Break
}

try {
  $s = Get-Item "IIS:\sites\$siteName" -ErrorAction SilentlyContinue
  
} catch {
  # http://help.octopusdeploy.com/discussions/problems/5172-error-using-get-website-in-predeploy-because-of-filenotfoundexception
  $s = Get-Item "IIS:\sites\$siteName" -ErrorAction SilentlyContinue
}

if (!$s) { throw "Site (or application) $siteName not found"}


function Give-Access ([String] $siteName, [String] $path, [String] $permission)
{
    Write-Host "Giving '$siteName' '$permission' permissions to '$path'"

    $Ar = New-Object System.Security.AccessControl.FileSystemAccessRule("$siteName", "$permission", 'ContainerInherit,ObjectInherit', 'None', 'Allow')
    $Acl = (Get-Item $path).GetAccessControl('Access')
    $Acl.SetAccessRule($Ar)
    Set-Acl -path $path -AclObject $Acl

    Write-Host "Done"
}

$appDataPath = Join-Path $s.PhysicalPath "App_Data";


New-Item -ItemType Directory -Force -Path $appDataPath
Give-Access "IIS AppPool\$siteName" $appDataPath 'Modify'