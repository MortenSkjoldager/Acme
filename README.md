# Acme

Unfortunately this project can only be run on windows.

##Getting started with the project:

1. Navigate under the folder Acme/App and run the following two commands:

* NPM Install
* NPM Run Build

2. Set connection strings to SQL server under 
* Acme/web.config
* Acme.Runner/App.Config

3. Run the Runner console application. This will setup the database and generate 100 keys that will be exported to c:\tmp\Serialnumbers-{tick}.txt

You should now be able to run the website by hitting F5.
