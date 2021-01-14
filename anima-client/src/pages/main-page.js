import React from 'react';
import './style/main-page.css';
import SpellTable from '../components/main/spells/spell-table';
import Character from '../components/main/character/character';

import {
    Switch,
    Route,
} from "react-router-dom";

class MainPage extends React.Component {

    render() {
        return <div className="main-page">
            <Switch>
                <Route path="/Character" component={Character} />
                <Route path="/Spells" component={SpellTable} />
                <Route path="/Notes">
                    <div>
                        Todo
                    </div>
                </Route>
            </Switch>
        </div>;
    }
}

export default MainPage;
