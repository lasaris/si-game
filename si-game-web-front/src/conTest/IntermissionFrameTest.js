import React, { Component } from 'react';
import Select from 'react-select';

class intermissionFrameTest extends Component {
    state = {
        type: "",
        text: "",
        questions: [],
        button : {},
        currentValue : ""
    }
    
    setCurrentValue(value){
        this.setState({currentValue: value});
    }

    render()
    {
        const options = [
            { value: 'Text', label: 'Text' },
            { value: 'Question', label: 'Question' },
            { value: 'Multichoice question', label: 'Multichoice question' },
            { value: 'User input', label: 'User input' }
          ];
        return (
        <div>
            Select type of frame.
            <Select onChange={(event) => this.setCurrentValue(event.value)} 
                value={this.state.currentValue} 
                options={options} />

            <label>Text:</label>
            <input type="text"></input>
        </div>);
    }
};

export default intermissionFrameTest;