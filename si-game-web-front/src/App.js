import React, { Component } from 'react';
import AppLayout from './components/AppLayout/AppLayout';
import ScenarioBuilder from './containers/ScenarioBuilder/ScenarioBuilder';

class App extends Component {
  render() {
    return (
      <AppLayout>
        <ScenarioBuilder>
        </ScenarioBuilder>
      </AppLayout>
    );
  }
}

export default App;
