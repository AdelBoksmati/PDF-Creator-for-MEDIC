import React, { useState } from 'react';

function Form({ onNext, onFormDataChange, formData }) {
  const [name, setName] = useState(formData.name || 'John Doe');
  const [email, setEmail] = useState(formData.email || 'john.doe@example.com');
  const [password, setPassword] = useState(formData.password || 'password123');
  const [confirmPassword, setConfirmPassword] = useState(formData.confirmPassword || 'password123');
  const [phoneNumber, setPhone] = useState(formData.phoneNumber || '1234567890');
  const [address, setAddress] = useState(formData.address || '123 Main Street');
  const [city, setCity] = useState(formData.city || 'Anytown');
  const [province, setProvince] = useState(formData.province || 'CA');
  const [zipCode, setZipCode] = useState(formData.zipCode || '12345');
  const [country, setCountry] = useState(formData.country || 'USA');
  const [dateOfBirth, setDateOfBirth] = useState(formData.dateOfBirth || '01/01/1990');

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = { name, email, password, confirmPassword, phoneNumber, address, city, province, zipCode, country, dateOfBirth };
    onFormDataChange(data);
    onNext();
  };

  const handleClearForm = () => {
    setName('');
    setEmail('');
    setPassword('');
    setConfirmPassword('');
    setPhone('');
    setAddress('');
    setCity('');
    setProvince('');
    setZipCode('');
    setCountry('');
    setDateOfBirth('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Name:
        <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
      </label>
      <label>
        Email:
        <input type="text" value={email} onChange={(e) => setEmail(e.target.value)} />
      </label>
      <label>
        Password:
        <input type="text" value={password} onChange={(e) => setPassword(e.target.value)} />
      </label>
      <label>
        Confirm Password:
        <input type="text" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} />
      </label>
      <label>
        Phone Number:
        <input type="text" value={phoneNumber} onChange={(e) => setPhone(e.target.value)} />
      </label>
      <label>
        Address:
        <input type="text" value={address} onChange={(e) => setAddress(e.target.value)} />
      </label>
      <label>
        City:
        <input type="text" value={city} onChange={(e) => setCity(e.target.value)} />
      </label>
      <label>
        Province:
        <input type="text" value={province} onChange={(e) => setProvince(e.target.value)} />
      </label>
      <label>
        Zip Code:
        <input type="text" value={zipCode} onChange={(e) => setZipCode(e.target.value)} />
      </label>
      <label>
        Country:
        <input type="text" value={country} onChange={(e) => setCountry(e.target.value)} />
      </label>
      <label>
        Date of Birth:
        <input type="text" value={dateOfBirth} onChange={(e) => setDateOfBirth(e.target.value)} />
      </label>
      <button type="submit">Next</button>
      <button type="button" onClick={handleClearForm}>Clear</button>
    </form>
  );
}

export default Form;
