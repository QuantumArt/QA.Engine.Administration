param(
[string] $name = "qp",
[string] $root = "D:\tfs\git\QA.Engine.Administration\QA.Engine.Administration.WebApp"
)


# restart as admin
If (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
{   
    $arguments = "-noexit & '" + $myinvocation.mycommand.definition + "'"
    Start-Process powershell -Verb runAs -ArgumentList $arguments
    Break
}


function Give-Access ([String] $name, [String] $path, [String] $permission)
{
    Write-Host "Giving '$name' '$permission' permissions to '$path'"

    $Ar = New-Object System.Security.AccessControl.FileSystemAccessRule("$name", "$permission", 'ContainerInherit,ObjectInherit', 'None', 'Allow')
    $Acl = (Get-Item $path).GetAccessControl('Access')
    $Acl.SetAccessRule($Ar)
    Set-Acl -path $path -AclObject $Acl

    Write-Host "Done"
}

$appData = Join-Path $root "App_Data";


New-Item -ItemType Directory -Force -Path $appData
Give-Access "IIS AppPool\$name" $appData 'Modify'