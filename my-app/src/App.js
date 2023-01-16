import React, { useRef, useState } from 'react';
import { Document, Page } from 'react-pdf';
import { pdfjs } from 'react-pdf';
import './App.css';
import MyForm from './form.js';
import FileSaver from 'file-saver';
import jsPDF from 'jspdf';

pdfjs.GlobalWorkerOptions.workerSrc = `//cdnjs.cloudflare.com/ajax/libs/pdf.js/${pdfjs.version}/pdf.worker.js`;

function App() {

  const pdfRef = useRef(null);
  const [formData, setFormData] = useState({});

  function handleFormChange(event) {
    setFormData({
      ...formData,
      [event.target.name]: event.target.value
    });
  }

  function downloadPDF() {
    const doc = new jsPDF();
    doc.text("Hello world!", 10, 10); // This is an example, putting in formdata does not work or even JSON.stringify(formData)
    doc.save('my-form.pdf');
  }
  
  return (
    <div className="App">
      <header className="App-header">
        <h1>Registration Form</h1>
        <MyForm />

        <button onClick={downloadPDF}>Download PDF</button>

        <Document file="my-form.pdf" ref={pdfRef}>
          <Page>
            <MyForm handleFormChange={handleFormChange}/>
          </Page>
        </Document>
      </header>
    </div>
  );
}

export default App;