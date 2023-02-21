import React, {  useState } from 'react';
import './App.css';
import MyForm from './form.js';

function App() {

  const [formData, setFormData] = useState({});

  function handleFormChange(event) {
    setFormData({
      ...formData,
      [event.target.name]: event.target.value
    });
  }

  return (
    <div className="App">
      <header className="App-header">
        <h1>Registration Form</h1>

        <MyForm handleFormChange={handleFormChange}/>

      </header>
    </div>
  );
}

export default App;