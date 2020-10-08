import React from 'react';
import FormWrapper from '../../../formwrapper';

const intermissionModule = (props) => {
    return (
    <FormWrapper handleAddForm = {props.handleAddForm}
                 visibleForm = {props.visibleForm}
                 showFormBool = {"ShowIntermissionModuleForm"}
                 addName="Add intermission module"
                 otherComponents={props.children}>
        <div> 
                <label>Frame id that is visible in the beggining:</label>
                <input type="number"></input>
        </div>
    </FormWrapper>);
};

export default intermissionModule;
