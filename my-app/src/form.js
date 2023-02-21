import React, { useState, useRef } from 'react';
import SignatureCanvas from 'react-signature-canvas';

function MyForm() {
  const [formData, setFormData] = useState({});
  const sigPad = useRef();

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  }

  const handleSubmit = (event) => {
    event.preventDefault();

    const signatureData = sigPad.current.toDataURL();
    const updatedFormData = { ...formData, signature: signatureData };

    console.log("https://localhost:7157/api/Person?"+JSON.stringify(updatedFormData));

    // Sending data to backend
    fetch('https://localhost:7157/api/Person/GeneratePDFSavedToServer/?', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(updatedFormData)
    })
    .then(res => res.json())
    .then(response => console.log('Success:', JSON.stringify(response)))
    .catch(error => console.error('Error:', error));
  };

  const handleClear = () => {
    sigPad.current.clear();
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Name:
        <input type="text" name="name" onChange={handleChange} />
      </label>
        <label>
        Email:
        <input type="text" name="email" onChange={handleChange} />
        </label>
        <label>
        Password:
        <input type="text" name="password" onChange={handleChange} />
        </label>
        <label>
        Confirm Password:
        <input type="text" name="confirmPassword" onChange={handleChange} />
        </label>
        <label>
        Phone Number:
        <input type="text" name="phoneNumber" onChange={handleChange} />
        </label>
        <label>
        Address:
        <input type="text" name="address" onChange={handleChange} />
        </label>
        <label>
        City: 
        <input type="text" name="city" onChange={handleChange} />
        </label>
        <label>
        Province: 
        <input type="text" name="province" onChange={handleChange} />
        </label>
        <label>
        Zip Code:
        <input type="text" name="zipCode" onChange={handleChange} />
        </label>
        <label>
        Country:
        <input type="text" name="country" onChange={handleChange} />
        </label>
        <label>
        Date of Birth:
        <input type="text" name="dateOfBirth" onChange={handleChange} />
        </label>
        

        <SignatureCanvas
        ref={sigPad}
        canvasProps={{
          style: {
            background: 'white',
            border: '1px solid white',
            width: '100%',
            height: '9rem'
          }
        }}
      />
      <button type="button" onClick={handleClear}>Clear Signature</button>

      <button type="submit">Submit</button>

    </form>

  );
}

export default MyForm;