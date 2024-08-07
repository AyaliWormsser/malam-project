import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
const AddWorkReport = ({ onAdd }) => {
    const [name, setName] = useState('');
    const [numOfHours, setNumOfHours] = useState('');
    const navigate = new useNavigate();
  

    const handleAddWorkReport = (e) => {
        e.preventDefault();

        const newWorkReport = {
            name,
            numOfHours
        };

        onAdd(newWorkReport);

        setName('');
        setNumOfHours('');
        navigate('/');
    };

    return (
        <form onSubmit={handleAddWorkReport}>
            <div>
                <label>
                    Nmae:
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
            
            <button type="submit">Add WorkReport</button>
        </form>
    );
};

export default AddWorkReport;
