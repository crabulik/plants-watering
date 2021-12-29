# plants-watering
Port of my plants watering service for RaspberyPi to .net6


## How to prepare your Raspberry for development

- validate and prepare your Pi for the SSH [Guide](https://www.raspberrypi.com/documentation/computers/remote-access.html#setting-up-an-ssh-server)

- Install .NET on your PI using [the next guide](https://www.digitalocean.com/community/tutorials/how-to-create-a-self-signed-ssl-certificate-for-nginx-on-debian-8)

- Configure Nginx on PI usint [the next guide](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-6.0)

- Additional preparation from [the next guide](https://thomaslevesque.com/2018/04/17/hosting-an-asp-net-core-2-application-on-a-raspberry-pi/)

- Configure the self-signed SSL for NGINX using [tne next link](https://www.digitalocean.com/community/tutorials/how-to-create-a-self-signed-ssl-certificate-for-nginx-on-debian-8)


## Build and Run the Remote Debuging

- Select the root directory of the repo

```
cd ${PLANTS_WATERING_DIR}\src
```

- Build the project

```
dotnet build
```

- Prepare the Publish artifacts

```
dotnet publish -o plants-watering
```

- Copy the artifacts to the Pi

```
scp -r plants-watering/* pi@raspberrypi:/home/pi/plants-watering/
```

- Enjoy debugging via VSC Run and Debug with .NET Remote Lunch

## TODO: Final deployment via SystemD and preparation for SystemD integration