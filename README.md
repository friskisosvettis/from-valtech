# friskis_sitecore

## How to set up the environment

### The solution is based on the following technologies:
- Sitecore 8.2 rev. 161115 (In SIM Version 8.2 and Revision 161115 - Update1 )
- ASP.NET 4.6.1
- SQL Server 2012 (or later)
- Visual Studio 2015
- Hedgehog TDS 5.5 
- MongoDB v. 2.6 (optionally robomongo, if you want a GUI)
- Node.JS 6
- Gulp (latest)
- Bower (Latest)
- Git
 
 
### LICENSES
You need to get a couple of licenses, if you don’t already have them.
 
- Sitecore developer license.
- TDS license.
 
 
### MongoDB installation
Download the correct version of MongoDB and run the installer.
 
After that has finished, you need to install MongoDB as a windows service.
 
First, create a few folders: 
- one for Mongo databases
- one for Mongo logfiles
These folders can be anywhere on your local drives. If in doubt, you can create them in your MongoDB install directory.
 
Then open a command prompt as administrator and run the following command, making sure to replace the file paths:
mongod --dbpath=“PathToMongoDatabaseDir" —logpath=“PathToMongoLogFileDir” –install
 
This will install a Windows service called MongoDB service.
 
Now run the following command to open the services window:
services.msc
 
Find the MongoDB service and start it.
 
If you installed RoboMongo, you can now use it to connect to localhost:27017.

## INITIAL LOCAL SETUP
These are the steps to create a full local environment. See sections below for detailed info on each step.
 
Install the URL-Rewrite module from Microsoft (if not installed already): http://www.iis.net/downloads/microsoft/url-rewrite
Checkout GIT repository locally from: https://github.com/valtech/friskis_sitecore
Install Sitecore Instance Manager (SIM) if you do not already have it installed, and set it up

Local solution path (git checkout root): C:\Solutions\FOS\FOS.Website
Default Website root path: C:\Websites\FOS.website
Default IIS binding: http://fos.website.local/
Use SIM to install a raw Sitecore website
Install Node.js v. 6 - https://nodejs.org/en/download/
Install command line dependencies using the command line. Run the following commands:

```
npm install --global gulp-cli
npm install --global bower
```
Still using the command line, navigate to your solution directory. Now run the following commands:

```
npm install
```
Run the Gulp task “Full-Publish”. Either

Run “gulp Full-Publish" on the command line, or
Open Visual Studio, open the “Task Runner” window and double-click "Initial-Setup”
Login to the Sitecore interface (using admin : b ) and do a full publish of the website
Check that your local environment is running by browsing to http://fos.website.local/

### Encryption Changed
After full publish has run the HashAlgoritm for the encryption of local Users passwords has changed to SHA512. This includes Admin Password so this needs to be reset.
- Open file C:\Websites\FOS.Website\Website\sitecore\admin\ResetAdminPasswordToRightCrypt.aspx
- Change bool ThisIsChangedFromServer = false; to true
- Save
- Go to https://fos.website.local/sitecore/admin/ResetAdminPasswordToRightCrypt.aspx
- Copy the Password and Log in with Admin and newPassword on https://fos.website.local/sitecore
- Change back ThisIsChangedFromServer to false in file and save after you have changed your admin Password.

### Solr installation
1. Go to https://bitnami.com/stack/solr/installer and Download Installer (When Writing it was bitnami-solr-6.5.1)
2. Install Bitnami ( Uncheck Bitnami cloud Hosting )
3. Verify that it works on http://localhost:8983/
4. Unpack Project Indexes to C:\Bitnami\solr-6.5.0-0\apache-solr\server\solr (Make sure that the Indexes are in the *\solr directory and not a subfolder)
5. Run Program Bitnami Apache Solr Stack Manager Tool
6. Go to Tab Manage Servers
7. Restart All
8. Got to http://localhost:8983/solr/#/~cores/sitecore_analytics_index verify that all indexes are there.
10. Go to visual studio
11. Rebuild Solution
12. Run Full-Publish in Gulp Task
	(The Magic is in z-apply-config-transformation)

#### RUN THE STYLEGUIDE LOCALLY
In order to run the styleguide locally: 
Use the command line and run "gulp--staticsite"

Then you will see a static version of the site, a lot of the solutions page types are created here as templates, together 
with an index.html file that is used to list all components/modules, colors and describe the grid.

All front end assets (html template files, fonts, images, scss and js is located in the assets folder in the repo)

For scss, the naming convention BEM (https://en.bem.info/methodology/quick-start/) is used.
```
/* Block component */
.btn {}

/* Element that depends upon the block */ 
.btn__price {}

/* Modifier that changes the style of the block */
.btn--orange {} 
.btn--big {}
```

### SITECORE DATABASE SERIALISATION
Sitecore Items are synchronised via Hedgehog TDS. Use version 5.5.

Use Gulp task to automatically batch sync everything in the solution to Sitecore.
Use normal (manual) sync or Sitecore Rocks to sync individual Sitecore items with TDS projects during development.


#### SIM SETUP
Download
The SIM application (https://marketplace.sitecore.net/en/Modules/Sitecore_Instance_Manager.aspx)
Zipped webroot of the correct Sitecore version (See below) from dev.sitecore.net and place in a folder on your machine that you wish to use for installing Sitecore instances using SIM (do not unzip). (eg. C:\Solutions\BuildLibrary\Sitecore )
Valtech Sitecore license (license.xml) and place in your SIM folder as well. (eg. C:\Solutions\BuildLibrary\Licenses )


### DEVELOPMENT

We use Gulp to automate. A lot.

Gulp tasks are used locally to:

- Restore NuGet packages from NuGet
- Deploy C# code from the solution directory to the webroot
- Apply config transformations to .config files
- Add TDS items to Sitecore databases
- Build and deploy assets (scss, js, images, fonts)
- Build a styleguide (ie. a static, local website, representing the front-end code produced so far)
- Set up Sitecore to use Solr

On build server, a tailored gulp task is called, which will produce the necessary NuGet packages for deployment to any environment.

Gulp commands can be run using the “Task Runner” window in Visual Studio or using the command line.
 
Some tasks will produce more diagnostic output when called with the —verbose flag. This is possible on the command line - but not in Visual Studio’s Task Runner


### DEPLOYING PROJECTS
As mentioned, Gulp handles a lot of our automated tasks.

On local and build environments:
- Restore NuGet packages
- Compile, obfuscate and minify SASS files to one big style.css
- Compile, obfuscate and minify javascript files to one big bundle.js
- Copy files (with an optional “watch” local feature for local development) to webroot
- C# files, using MSBuild deployment
- Fonts
- Compiled CSS
- Compiled JS

#### Only on local environment:
Transform config files in webroot (using the config transformation powershell script included in the solution)
Sync the contents of all TDS projects to Sitecore.

#### Only on build environment:
Clean the “dist” directory used for NuGet packaging, so old files will not be deployed
Build TDS update packages with consecutive prefixes (ie. 001_, 002_, etc.), to ensure correct installation order in Octopus
Copy TDS update packages in a flattened structure to NuGet source directory
 

 When preparing a deployment, a user will run the "Build (Octopus)” build on TeamCity. This will produce the Nuget packages for deployment:
Custom web-root, to be deployed on top of a raw Sitecore Instance
TDS update packages without editor conten
TDS update packages with content (for all environments)

The new NuGet NuGet packages will then be exposed in the TeamCity feed.

A user can then use Octopus Deploy to deploy those NuGet packages. Octopus will:
Get Sitecore raw webroot and Hedgehog UpdatePackageInstaller NuGet packages from nuget.valtech.dk
Get custom web-root and TDS NuGet packages from the TeamCity feed ( build.valtech.dk )
Deploy NuGet packages to newly created folders (to enable quick rollback on files) and then create / update IIS site
Apply transformation files for each environment.
Delete all config transformation files after transformation is done
Ensure Hosts File entry for the current website exists on web server to allow KeepAlive to connect
Prewarm website to enable fast response time after fresh deployment
Update Sitecore with all deployed TDS packages from TDS_No_Content
Update Sitecore with all deployed TDS packages from TDS_Content (only QA)
Delete Hedgehog UpdatePackageInstaller for security reasons
Delete old deployment folders to optimise disk space (leaving the latest 3 in place).