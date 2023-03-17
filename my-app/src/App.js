import React, { useState } from 'react';
import Form from './Form';
import Signature from './Signature';
import Header from './Header';
import Footer from './Footer';
import Sidebar from './Sidebar';
import './App.css';


function App() {
  const [formData, setFormData] = useState({});
  const [showWelcome, setShowWelcome] = useState(true);
  const [showForm, setShowForm] = useState(false);
  const [showSignature, setShowSignature] = useState(false);
  const [showConfirmation, setShowConfirmation] = useState(false);

  const handleStart = () => {
    setShowWelcome(false);
    setShowForm(true);
  };

  const handleNext = () => {
    setShowForm(false);
    setShowSignature(true);
  };

  const handleBack = () => {
    setShowForm(true);
    setShowSignature(false);
  };

  const handleFormDataChange = (data) => {
    setFormData(data);
  };

  const handleConfirmation = () => {
    setShowSignature(false);
    setShowConfirmation(true);
    setFormData({}); // Clear the formData
  };

  const handleRestart = () => {
    setFormData({});
    setShowWelcome(true);
    setShowForm(false);
    setShowSignature(false);
    setShowConfirmation(false);
  };

  return (
    <div className="App">
      <Header />
      <div className="App-main">
        <Sidebar />
        <div className="App-content">
        {showWelcome && (
        <div className="Welcome">
          <h1>Welcome to Our App</h1>
          <p>Click the button below to get started.</p>
          <button onClick={handleStart}>Get Started</button>
        </div>
      )}
      {showForm && (
        <Form
          onNext={handleNext}
          onFormDataChange={handleFormDataChange}
          formData={formData}
        />
      )}
      {showSignature && (
        <Signature
          onBack={handleBack}
          formData={formData}
          onConfirmation={handleConfirmation}
        />
      )}
      {showConfirmation && (
        <div className="Confirmation">
          <h1>Confirmation</h1>
          <p>Your information has been submitted successfully.</p>
          <button onClick={handleRestart}>Back to Welcome Page</button>
        </div>
      )}
        </div>
      </div>
      <Footer />
    </div>
  );
}

export default App;

