import React, { useState } from 'react';

function MyForm() {
  const [formData, setFormData] = useState({});

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  }

  const handleSubmit = (event) => {
    event.preventDefault();

    // console.log("https://localhost:7157/api/Person?"+JSON.stringify(formData));

    // Sending data to backend
    fetch('https://localhost:7157/api/Person?', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData)
    })
    .then(res => res.json())
    .then(response => console.log('Success:', JSON.stringify(response)))
    .catch(error => console.error('Error:', error));
  }

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
        
      <button type="submit">Submit</button>
    </form>
  );
}

export default MyForm;