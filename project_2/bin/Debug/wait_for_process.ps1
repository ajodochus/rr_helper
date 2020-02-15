function Wait-ForProcess
{
    param
    (
        $Name = 'VDogSchedularCheckIn',

        [Switch]
        $IgnoreAlreadyRunningProcesses
    )

    if ($IgnoreAlreadyRunningProcesses)
    {
        $NumberOfProcesses = (Get-Process -Name $Name -ErrorAction SilentlyContinue).Count
    }
    else
    {
        $NumberOfProcesses = 0
    }


    Write-Host "Waiting for $Name" -NoNewline
    while ( (Get-Process -Name $Name -ErrorAction SilentlyContinue).Count -eq $NumberOfProcesses )
    {
        Write-Host '.' -NoNewline
        Start-Sleep -Milliseconds 400
    }
}
Wait-ForProcess