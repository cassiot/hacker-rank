cls

$algo = read-host -Prompt "choose algo: "

write-host "pablu"
Get-Content .\input_pablu.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: ?"
write-host

write-host "cvt"
Get-Content .\input_cvt.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 8"
write-host

write-host "00"
Get-Content .\input00.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 2"
write-host

write-host "01"
Get-Content .\input01.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 0"
write-host

write-host "03"
Get-Content .\input03.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 1"
write-host

write-host "07"
Get-Content .\input07.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 3"
write-host

write-host "08"
Get-Content .\input08.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 4"
write-host

write-host "09"
Get-Content .\input09.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 5"
write-host

write-host "10"
Get-Content .\input10.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 3"
write-host

write-host "12"
Get-Content .\input12.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 16"
write-host

write-host "20"
Get-Content .\input20.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 24"
write-host

write-host "21"
Get-Content .\input21.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 15"
write-host

write-host "24"
Get-Content .\input24.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 49999"
write-host

write-host "26"
Get-Content .\input26.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 49998"
write-host

write-host "27"
Get-Content .\input27.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 49999"
write-host

write-host "28"
Get-Content .\input28.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 3"
write-host

write-host "29"
Get-Content .\input29.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 2"
write-host

write-host "30"
Get-Content .\input30.txt | .\PoisonousPlants.exe algo $algo
write-host "correct: 3"

