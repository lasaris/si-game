import React, { useState } from 'react';
import Select from 'react-select';
import FormWrapper from '../../formwrapper';

const intermissionFrameComponent = (props) => {
    const options = [
        { value: 'Text', label: 'Text' },
        { value: 'Question', label: 'Question' },
        { value: 'Multichoice question', label: 'Multichoice question' },
        { value: 'User input', label: 'User input' }
      ];
    const [currentValue, setCurrentValue] = useState(0);
    return (
    <FormWrapper handleAddForm = {props.handleAddForm}
                 visibleForm = {props.visibleForm}
                 showFormBool = {"ShowIntermissionFrameForm"}
                 addName="Add intermission frame">
    <div>
        Select type of frame.
        <Select onChange={(event) => setCurrentValue(event.value)} 
                value={props.currentValue} 
                options={options} />

        <label>Text:</label>
        <input type="text"></input>
    </div>
    </FormWrapper>); 
};

export default intermissionFrameComponent;