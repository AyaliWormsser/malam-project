import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";


const EditWorkReport = ({ workReport, onEdit }) => {
  const [name, setName] = useState('');
  const [numOfHours, setNumOfHours] = useState('');
  const navigate = new useNavigate();

  useEffect(() => {
    if (workReport) {
      setName(workReport.name);
      setNumOfHours(workReport.numOfHours);
    }
  }, [workReport]);

  const handleEditWorkReport = async (e) => {
    e.preventDefault();

    const updatedWorkReport = {
      ...workReport,
      name,
      numOfHours
    };

    try {
      
      await axios.put(`https://localhost:7059/api/WorkReport/${workReport.id}`, updatedWorkReport);
     
      onEdit(workReport.index, updatedWorkReport);
      navigate('/');
    } catch (error) {
      console.error('Error updating workReport:', error);
    }
  }

  return (
    <form onSubmit={handleEditWorkReport}>
      <div>
        <label>
          Name:
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Enter the name of the task"
            required
          />
        </label>
      </div>
      <div>
        <label>
          Num Of Hours:
          <input
            type="number"
            value={numOfHours}
            onChange={(e) => setNumOfHours(e.target.value)}
            placeholder="Enter num of hours"
            required
          />
        </label>
      </div>
      <button type="submit">Save Changes</button>
    </form>
  );
};

export default EditWorkReport;


