# COMPCO867-Software-Engineering-Project

This project is a combination of a React frontend and a .NET backend, using the VSCode extension .vs and mp-app for the frontend and the .NET framework for the backend.

## Frontend

To run the React frontend, use the .vs and mp-app extension in VSCode. The frontend code can be found in the `src` directory.

## Backend

The backend is built with the .NET framework and can be opened using the .sln file in the MEDIC5 directory. The backend code can be found in the `Controllers` and `Models` directories.

Downloaded the 'Microsoft.AspNetCore.Cors' with the NuGet application

## Running the project

1. Open the project in VSCode and start the React development server by running the command `npm start` in the terminal.
2. Open the .sln file in the MEDIC5 directory and run the project in Visual Studio.
3. The project should now be running on `http://localhost:3000/`

## Document Assembly
The Documents folder is where the document assembly happens. It is "Scaffolded" from the Models folder. This is where the backend takes the data from the frontend and creates a PDF document.

## Object Validation
The Controllers folder is where the object validation takes place. This is where the backend ensures that the data received from the frontend is valid and appropriate before creating the PDF document. Once the validation is complete, the PDF document is sent back to the frontend.
