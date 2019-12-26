cls

#$algo = read-host -Prompt "choose algo: "

write-host "02"
Get-Content .\input02.txt | .\ANDxorOR.exe
$c = Get-Content .\output02.txt
write-host "correct:" $c
write-host

write-host "03"
Get-Content .\input03.txt | .\ANDxorOR.exe
$c = Get-Content .\output03.txt
write-host "correct:" $c
write-host

write-host "04"
Get-Content .\input04.txt | .\ANDxorOR.exe
$c = Get-Content .\output04.txt
write-host "correct:" $c
write-host

write-host "07"
Get-Content .\input07.txt | .\ANDxorOR.exe
$c = Get-Content .\output07.txt
write-host "correct:" $c
write-host

write-host "09"
Get-Content .\input09.txt | .\ANDxorOR.exe
$c = Get-Content .\output09.txt
write-host "correct:" $c
write-host

write-host "16"
Get-Content .\input16.txt | .\ANDxorOR.exe
$c = Get-Content .\output16.txt
write-host "correct:" $c
write-host

write-host "26"
Get-Content .\input26.txt | .\ANDxorOR.exe
$c = Get-Content .\output26.txt
write-host "correct:" $c
write-host

write-host "27"
Get-Content .\input27.txt | .\ANDxorOR.exe
$c = Get-Content .\output27.txt
write-host "correct:" $c
write-host
