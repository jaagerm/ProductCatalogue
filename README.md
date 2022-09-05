# ProductCatalogue
This application provides a demo solution for a usecase, where employees need to update an Excel based list of products in a way, that these changes would be visible for other users on a web page.
The demo setup consists of three applications:
- **ExcelAddin** - a React application for an AddIn that runs on Excel. It's purpose is to read Product data from an excel sheet on a button press and deliver that data through an API post request to another service. Addins in Excel are running on the Internet Explorer or Edge browser engine. More info about that here: https://docs.microsoft.com/en-us/office/dev/add-ins/overview/office-add-ins
- **DataService** - a .NET Core service which provides an API for receiving Product data.
- **Web** - an Angular based application which periodically polls the **DataService** for product information.

**Follow the video for a walkthrough of how the application works:**
[![Watch the video](https://i.ibb.co/fpZ9HTJ/Product-Catalogue.png)](https://www.youtube.com/watch?v=oKeQjzlPkvo)

## Requirements for running this demo
- Have MS Excel installed. Tested with the desktop version of Excel 2016.
- .NET Core SDK
- Node
## How to install and run
- Clone this repository
- run "npm install" within the **ExcelAddin** project root folder
- run "npm run start:desktop" within the **ExcelAddin** project root folder
- This should open up Excel with the AddIn on the right side


- run “npm install” within the **Web** project root folder
- run "ng serve" within the **Web** project root folder
- Open up the web page with the url pointed out in the output of the "ng serve" command
- Open the "Products" tab on the webpage


- run "dotnet run" within the **DataService** root folder


- Rename the Excel sheet as "Data"
- Add column headers into the excel sheet starting from A1 as follows: ID, Name, Producer, Quantity
- Add data into the following row starting from A1, for example such: 1, Computer, Apple, 12
- You can add as many rows of data as you want
- Then fill out "Employee ID" on the Addin page and press "Send Data"
- Within a few seconds, you should see the data appear on the Product tab of the Webpage you opened earlier
