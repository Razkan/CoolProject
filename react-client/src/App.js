import React from 'react';
import './App.css';
import StartPage from './shared/pages/start-page';

class App extends React.Component {

	render() {
		return (
			<div className="app">
				<StartPage />
			</div>
		);
	}
}

export default App;
