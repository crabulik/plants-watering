cd src
Remove-Item –path plants-watering –recurse
dotnet publish -o plants-watering
scp -r plants-watering/* pi@raspberrypi:/home/pi/plants-watering/