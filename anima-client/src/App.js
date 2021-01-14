import React from 'react';
import './App.css';
import Navigation from './components/navigation';
import SidebarPage from './pages/sidebar-page';
import MainPage from './pages/main-page';

class App extends React.Component {

	render() {
		return (
			<div className="app">
				
				{/* <Navigation /> */}
				<div className="content">
					{/* <Sidebar /> */}
					<SidebarPage />
					<MainPage />
				</div>
			</div>
		);
	}
}

export default App;
