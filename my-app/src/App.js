import React from 'react';
import './App.css';
import MyForm from './form.js';

// how to start - Marek's Notes
// cd '.\COMPCO867 Software Engineering Project\my-app' 
// INSTALL THIS IN THE ROOT FOLDER OF THE PROJECT
// npm install @react-pdf/renderer --save


// npm start


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Registration Form</h1>
        <div>
          <MyForm />
        </div>

      </header>
    </div>
  );
}

export default App;
