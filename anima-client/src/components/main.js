import React from 'react';
import './style/main.css';
import Kanban from './kanban/kanban';

class Main extends React.Component {

    render() {
        return <div className="main">
            <Kanban />
        </div>;
    }
}

export default Main;
