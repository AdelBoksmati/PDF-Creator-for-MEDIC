import React, { useRef } from 'react';
import SignatureCanvas from 'react-signature-canvas';

function Signature({ onBack, formData, onConfirmation }) {
  const sigPad = useRef();

  const handleSubmit = (event) => {
    event.preventDefault();
    if (sigPad.current.isEmpty()) {
      alert('Please provide a signature.');
      return;
    }
    const signatureData = sigPad.current.toDataURL();
    const updatedFormData = { ...formData, signature: signatureData };
    console.log(formData, signatureData);
    
    // Send the form data to the backend server using the `fetch` API
    fetch('https://localhost:7157/api/Person/GeneratePDFSavedToServer/?', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(updatedFormData)
    })
    .then(res => res.json())
    .then(response => {
      console.log('Success:', JSON.stringify(response));
      sigPad.current.clear();
      onConfirmation();
    })
    .catch(error => console.error('Error:', error));
  };

  const handleSecondSubmit = (event) => {
    event.preventDefault();

    if (sigPad.current.isEmpty()) {
      alert('Please provide a signature.');
      return;
    }

    const signatureData = sigPad.current.toDataURL();
    const updatedFormData = { ...formData, signature: signatureData };

    // Send the form data to the backend server using the `fetch` API
    fetch('https://localhost:7157/api/Person/CheckDetails/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedFormData)
    })
        .then(response => {
            // If the response is OK, download a PDF file containing the details provided by the user
            if (response.ok) {
                return response.blob();
            }
            // Otherwise, throw an error
            throw new Error('Network response was not ok.');
        })
        .then(blob => {
            // create a link element to download the pdf file
            const link = document.createElement('a');
            link.href = URL.createObjectURL(blob);
            link.download = 'PersonDocument.pdf';

            // programmatically click the link to download the file
            link.click();

            sigPad.current.clear();
            onConfirmation();
        })
        .catch(error => console.error('Error:', error));
  };

  const handleClear = () => {
    sigPad.current.clear();
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Name:
        <input type="text" value={formData.name} disabled />
      </label>
      <label>
        Email:
        <input type="text" value={formData.email} disabled />
      </label>
      <label>
        Password:
        <input type="text" value={formData.password} disabled />
      </label>
      <label>
        Confirm Password:
        <input type="text" value={formData.confirmPassword} disabled />
      </label>
      <label>
        Phone Number:
        <input type="text" value={formData.phoneNumber} disabled />
      </label>
      <label>
        Address:
        <input type="text" value={formData.address} disabled />
      </label>
      <label>
        City:
        <input type="text" value={formData.city} disabled />
      </label>
      <label>
        Province:
        <input type="text" value={formData.province} disabled />
      </label>
      <label>
        Zip Code:
        <input type="text" value={formData.zipCode} disabled />
      </label>
      <label>
        Country:
        <input type="text" value={formData.country} disabled />
      </label>
      <label>
        Date of Birth:
        <input type="text" value={formData.dateOfBirth} disabled />
      </label>
      <SignatureCanvas
        ref={sigPad}
        canvasProps={{
          width: 500,
          height: 200,
          style: {
            border: '1px solid black',
          },
        }}
      />
      <button type="button" onClick={handleClear}>Clear</button>
      <button type="submit">Submit</button>
      <button type="submit" onClick={handleSecondSubmit}>Check Details</button>
      <button type="button" onClick={onBack}>Back</button>
    </form>
  );
}

export default Signature;
