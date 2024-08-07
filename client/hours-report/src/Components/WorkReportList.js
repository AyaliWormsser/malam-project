import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";


const WorkReportList = ({ workReports, setWorkReports, setWorkReportToEdit, onDelete, fetchWorkReport }) => {
    const navigate = useNavigate();

    useEffect(() => {
        fetchWorkReport();
    }, [fetchWorkReport]);

    const handleAddWorkReport = () => {
        navigate('/add');
    };

    const handleEditWorkReport = (workReport, index) => {
        setWorkReportToEdit({ ...workReport, index });
        navigate('/edit');
    };

    const handleRemoveWorkReport = (index) => {
        onDelete(index);
    };

    return (
        <div>
            <h1>WorkReports List</h1>
            <button onClick={handleAddWorkReport}>Add WorkReport</button>

            <ul>
                {workReports.map((workReport, index) => (
                    <li key={index}>
                        <span>
                             name: {workReport.name}<>  </>  
                        </span>
                        <span>
                             num of hours:  {workReport.numOfHours}<>  </>
                        </span>
                        <button onClick={() => handleEditWorkReport(workReport, index)}>Edit WorkReport</button>
                        <button onClick={() => handleRemoveWorkReport(index)}>Delete WorkReport</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default WorkReportList;
