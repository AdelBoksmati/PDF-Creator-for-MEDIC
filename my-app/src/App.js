import React, { useRef, useState } from 'react';
import { Document, Page } from 'react-pdf';
import './App.css';
import MyForm from './form.js';

// how to start - Marek's Notes
// cd '.\COMPCO867 Software Engineering Project\my-app' 
// INSTALL THIS IN THE ROOT FOLDER OF THE PROJECT
// npm install react-pdf
// npm start


function App() {

  const url = useRef(null);

  const [pdfRef, setPdfRef] = useState(null);

  const downloadPDF = () => {
    if (pdfRef) {
        pdfRef.current.save("my-form.pdf");
    }
  };
  
  return (
    <div className="App">
      <header className="App-header">
        <h1>Registration Form</h1>
        <MyForm />

        <button onClick={downloadPDF}>Download PDF</button>
        <Document file={url} ref={setPdfRef}>
          <Page>
            <MyForm />
          </Page>
        </Document>
      </header>
    </div>
  );
}

export default App;
