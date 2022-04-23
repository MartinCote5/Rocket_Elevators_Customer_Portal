# Rocket Elevator Customer Portal

Week 11 - Understanding the .NET Framework


The portal is a personnal space for our customers to modify their own informations like their buildings.
They also have a list of their Buildings, batteries, columns and elevators!
Lastly there is also a  place to fill an intervention formular.


## Name of databases

`MartinCote` is the name for MySQL databases hosted on the Codeboxx aws account.


## How to connect to the databases with our service

To connect to a database, we use an environment variable (for informations about setting up an environment variable, view pages: [Linux](https://www.serverlab.ca/tutorials/linux/administration-linux/how-to-set-environment-variables-in-linux/), [MacOS](https://phoenixnap.com/kb/set-environment-variable-mac), [Windows](https://docs.oracle.com/en/database/oracle/machine-learning/oml4r/1.5.1/oread/creating-and-modifying-environment-variables-on-windows.html)). This variable is a connection string with the name `CONNECTION_STRING` and should looks something like this: 
``` 
 server=<HOST>;database=<DATABASE>;user=<USERNAME>;password=<PASSWORD>
```

## Explanatory video





-https://www.youtube.com/watch?v=NDIvmIJugOE