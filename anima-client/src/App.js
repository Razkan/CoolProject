import React from 'react';
import './App.css';
import Navigation from './components/navigation';
import Sidebar from './components/sidebar';
import Main from './components/main';

class App extends React.Component {
	render() {
		return (
			<div className="app">
				{/* <Navigation /> */}
				<div className="content">
					<Sidebar />
					<Main />
				</div>
			</div>
		);
	}
}

export default App;
