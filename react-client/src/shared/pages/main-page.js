import React from 'react';
import './style/main-page.css';
import SpellTable from '../components/main/spells/spell-table';
import Character from '../components/main/character/character';

import {
    Switch,
    Route,
    withRouter,
    Redirect
} from "react-router-dom";

class MainPage extends React.Component {

    render() {

        const { url } = this.props.match;

        return <div className="main-page">
            <Switch>
                <Route path={url + "/Character"} component={Character} />
                <Route path={url + "/Spells"} component={SpellTable} />
                <Route path={url + "/Notes"}>
                    <div>
                        Todo
                    </div>
                </Route>

                <Route path={url + "/"}>
                    <Redirect to={url + "/Spells"} />
                </Route>

            </Switch>
        </div>;
    }
}

export default withRouter(MainPage);
