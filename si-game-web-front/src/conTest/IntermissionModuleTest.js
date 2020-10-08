import React, { Component } from 'react';
import IntermissionFrameTest from './IntermissionFrameTest';

class intermissionModuleTest extends Component {
    state = {
        currentUnusedIntermissionFrameId : -1,
        intermissionFrames: []
    }

    addIntermissionFrame = () => {
        var newIntermissionFrame = { typeInput: "empty", intermissionFrameId: this.state.currentUnusedIntermissionFrameId };
        this.setState(prevState => (
            { 
                intermissionFrames: prevState.intermissionFrames.concat([newIntermissionFrame]),
                currentUnusedIntermissionFrameId: this.state.currentUnusedIntermissionFrameId + 1
            }));
    }
    
    render()
    {
        if(this.props.data.typeInput === "empty"){
            return (
                <div> 
                    <label>Frame id that is visible in the beggining:</label>
                    <input type="number" onChange={this.props.onChange}></input>
                    {this.state.intermissionFrames.map(input => 
                        <IntermissionFrameTest data={input}>
                        </IntermissionFrameTest>)}
                    <button onClick={this.addIntermissionFrame}>Add intermission frame</button>
                </div>
            );
        }
        if(this.props.data.typeInput === "fill"){
            return (
                <div>Intermission module filled.</div>
            )
        }
    }
};

export default intermissionModuleTest;