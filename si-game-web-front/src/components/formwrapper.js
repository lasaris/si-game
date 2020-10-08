import React, { useState } from 'react';

const formWrapper = (props) => {
    const [showOtherComponents, setShowOtherComponents] = useState(false);
    //let showOtherComponents = false;
    return(
    <div>
        {props.visibleForm ?
        <div>
            {props.children}
            {showOtherComponents ? props.otherComponents :
                <button onClick={() => {
                    //do submit logic
                    setShowOtherComponents(true);
                    props.handleAddForm(props.showFormBool, true);
                }}>Submit</button>}
        </div>
        : <button onClick={() => props.handleAddForm(props.showFormBool, true)}>{props.addName}</button>}
    </div>
    )
}

export default formWrapper;