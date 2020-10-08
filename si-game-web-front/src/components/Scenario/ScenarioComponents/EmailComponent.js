import React from 'react';

const emailComponent = () => {
    return (
    <div>
        <label>Sender:</label>
        <input type="email"></input>
        <label>Subject:</label>
        <input type="text"></input>
        <label>Date:</label>
        <input type="date"></input>
        <label>Content header:</label>
        <input type="text"></input>
        <label>Content footer:</label>
        <input type="text"></input>
        <label>Is email sent:</label>
        <input type="checkbox"></input>
        <label>Active:</label>
        <input type="checkbox"></input>
    </div>);
};

export default emailComponent;