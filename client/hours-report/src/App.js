import React, { useState, useEffect } from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import axios from 'axios';
import WorkReportList from './Components/WorkReportList';
import AddWorkReport from './Components/AddWorkReport';
import EditWorkReport from './Components/EditWorkReport';


function App() {
  
  const [workReports, setWorkReports] = useState([]);
  const [workReportToEdit, setWorkReportToEdit] = useState(null);
  const fetchWorkReport = async () => {
    try {
      const response = await axios.get('https://localhost:7059/api/WorkReport');
      console.log('Response data:', response.data); 
      setWorkReports(response.data);
    } catch (error) {
      console.error('Error fetching workReports:', error);
    }
  };

  useEffect(() => {
    fetchWorkReport();
  }, []);



  const addWorkReport = async (newWorkReport) => {
    try {
      await axios.post('https://localhost:7059/api/WorkReport', newWorkReport);
      fetchWorkReport();
    } catch (error) {
      console.error('Error adding workReport:', error);
    }
  };

  const editWorkReport = async (index, updatedWorkReport) => {
    try {
      await axios.put(`https://localhost:7059/api/WorkReport/${updatedWorkReport.id}`, updatedWorkReport);
      fetchWorkReport();
    } catch (error) {
      console.error('Error updating workReport:', error);
    }
  };


  const deleteWorkReport = async (id) => {
    try {
      await axios.delete(`https://localhost:7059/api/WorkReport/${id}`);
      fetchWorkReport(); 
    } catch (error) {
      console.error('Error deleting workReport:', error);
    }
  };

  return (
    <Router>
      <Routes>
        <Route path="/" element={<WorkReportList workReports={workReports} setWorkReports={setWorkReports} setWorkReportToEdit={setWorkReportToEdit} onDelete={deleteWorkReport} fetchWorkReport={fetchWorkReport} />} />
        <Route path="/add" element={<AddWorkReport onAdd={addWorkReport} />} />
        <Route path="/edit" element={<EditWorkReport workReport={workReportToEdit} onEdit={editWorkReport} />} />
      </Routes>
    </Router>
  );
}

export default App;
