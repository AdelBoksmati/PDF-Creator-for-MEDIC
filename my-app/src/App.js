import React, { useState } from 'react';
import Form from './Form';
import Signature from './Signature';

function App() {
  const [formData, setFormData] = useState({});
  const [showForm, setShowForm] = useState(true);
  const [showSignature, setShowSignature] = useState(false);

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

  return (
    <div className="App">
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
        />
      )}
    </div>
  );
}

export default App;
